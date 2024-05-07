using System.Runtime.ConstrainedExecution;
using Logic.Database.Models;
using Logic.ExternalConnection.Wireguard.Entities.WireGuard;
using Logic.ExternalConnection.Wireguard.Repositories;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Logic.Logic;

public class CertificateLogic: BaseLogic, ICertificateLogic
{
    #region Service constructor and injected dependencies
    private readonly IRepository<Certificate> _certificateRepository;
    private readonly IRepository<VpnUser> _vpnUserRepository;
    private readonly WireGuardRepository _wireGuardRepository;
    private readonly ILogger<CertificateLogic> _logger;
    public CertificateLogic(IRepository<Certificate> certificateRepository, WireGuardRepository wireGuardRepository, IRepository<VpnUser> vpnUserRepository, ILogger<CertificateLogic> logger)
    {
        _certificateRepository = certificateRepository;
        _wireGuardRepository = wireGuardRepository;
        _vpnUserRepository = vpnUserRepository;
        _logger = logger;
    }
    #endregion
    
    public async Task<IHandler<bool>> UpdateBytesInfo()
    {
        var certificates = _vpnUserRepository.Where(u => u.Certificate != null).Include(u => u.Certificate).ThenInclude(c => c.Server).Select(u => u.Certificate).ToList();
        foreach (var certificate in certificates)
        {
            await UpdateBytesForPeer(certificate);
        }
        
        await _certificateRepository.UpdateRangeSaveAsync(certificates);
        return true.Wrap();
    }

    public async Task UpdateBytesForPeer(Certificate certificate)
    {
            if (certificate!.Server == null)
            {
                _logger.LogCritical("Server is null for certificate {CertificateId:}", certificate.Id);
                return; // new HandlerException<Certificate>(_logger, $"Server is null for certificate {certificate.Id}", LogType.Critical);
            }

            var peerHandled = await _wireGuardRepository.GetInfo(certificate.Server.Host, certificate.PublicKey);
            if (peerHandled is HandlerException<Peer>)
                return; // new HandlerException<Certificate>(_logger, "");
            var peer = peerHandled.Unwrap();
            certificate.ReceiveBytes = peer.ReceiveBytes;
            certificate.TransmitBytes = peer.TransmitBytes;
    }
}