using System.Text;
using Flurl.Http;
using Logic.ExternalConnection.Wireguard.Entities.WireGuard;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Logic.ExternalConnection.Wireguard.Repositories;

public class WireGuardRepository
{
    private static List<string>? _ips = null;
    private static List<string> _lazzyIps = _ips ?? InitIps(out _ips);

    private static List<string> InitIps(out List<string> ips) =>
        ips = Enumerable.Range(1, 255).Select(e => e.ToString()).ToList();
    
    private readonly IConfiguration _configuration;
    private readonly ILogger<WireGuardRepository> _logger;
    
    public WireGuardRepository(IConfiguration configuration, ILogger<WireGuardRepository> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> NewPeer(string host)
    {
        var cli =
            new FlurlClient($"http://{host}/v1/devices/wg0/")
                .WithHeader("Authorization", "Bearer capybara");
            var request = cli.Request($"peers/"); // last "/" so important

        var peers = await request.GetAsync().ReceiveJson<List<Peer>>();

        var lastOctets =
            peers
                .Where(p => p.AllowedIps != null && p.AllowedIps.Any())
                .Select(p => p.AllowedIps.First().Split('/').First().Split(".").Last()); // 192.168.1.12/32 => 12

        var newLastOctet = _lazzyIps.First(i => !lastOctets.Contains(i));

        string regularIp;
        if (peers.Count == 0)
        {
            regularIp = "10.13.37.1/32";
        }
        else
        {
            regularIp =
                peers.First(p => p.AllowedIps != null && p.AllowedIps.Any()).AllowedIps
                    .First(); 
        }
        var octetsAndCidr = regularIp.Split('/');
        var octets = octetsAndCidr.First().Split('.');
        octets[3] = newLastOctet;


        var peer = await request
            .PostJsonAsync(new
            {
                allowed_ips = new List<string> { $"{string.Join(".", octets)}/{octetsAndCidr.Last()}" }
            }).ReceiveJson<Peer>();

        return peer.UrlSafePublicKey;
    }

    public async Task DeletePeer(string host, string publicKey)
    {
        var cli =
            new FlurlClient($"http://{host}/v1/devices/wg0/")
                .WithHeader("Authorization", "Bearer capybara");
        var request = cli.Request($"peers/{publicKey}/"); // last "/" so important
        await request.DeleteAsync();
    }
    
    public async Task<string> TextConfig(string host, string publicKey)
    {
        var cli =
            new FlurlClient($"http://{host}/v1/devices/wg0/")
                .WithHeader("Authorization", "Bearer capybara");
        var request = cli.Request($"peers/{publicKey}/quick.conf");
        return await request.GetAsync().ReceiveString();
    }

    public async Task<byte[]> QrCodeConfig(string host, string publicKey)
    {
        return await $"http://{host}/v1/devices/wg0/peers/{publicKey}/quick.conf.png".WithHeader("Authorization", "Bearer capybara").GetBytesAsync();
    }

    public async Task<IHandler<Peer>> GetInfo(string host, string publicKey)
    {
        var cli =
            new FlurlClient($"http://{host}/v1/devices/wg0/")
                .WithHeader("Authorization", "Bearer capybara");
        var request = cli.Request($"peers/{publicKey}/"); // last "/" so important
        try
        {
            var peer = await request.GetAsync().ReceiveJson<Peer>();
            return peer.Wrap();
        }
        catch (Exception ex)
        {
            return new HandlerException<Peer>(_logger, "Wireguard repository info for peer not exist", LogType.Critical);
        }
    }
}