using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Logic.Model.Result.Shared;
using Logic.Externsions;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.ExternalConnection.TelegramSubscribers.Repositories;

public class TelegramAgentRepository
{
    private readonly List<string> _subscribersHosts;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TelegramAgentRepository> _logger;
    public TelegramAgentRepository(IConfiguration configuration, ILogger<TelegramAgentRepository> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _subscribersHosts = _configuration.GetSection("SubscribedTelegramBots").Get<List<string>>();
    }

    public async Task<IHandler<bool>> Notify(List<long> telegramIds, string message)
    {
        foreach (var request in _subscribersHosts.Select(host => new FlurlClient($"http://{host}/bot/")
                    .WithHeader("Authorization", "Bearer capybara")).Select(cli => cli.Request("send-message")))
        {
            try
            {
                var result = await request.PostJsonAsync(new { telegramIds = telegramIds, message = message });
                // TODO handle result
            }
            catch (Exception  exception)
            {
                _logger.LogError(exception.GetAllMessagesIntoString());
            }
        }

        return new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> PaymentNotify(long telegramId, int value)
    {
        _logger.LogInformation("PaymentNotify started....");
        foreach (var host in _subscribersHosts)
        {
            var request = new FlurlClient($"http://{host}/bot/")
                    .WithHeader("Authorization", "Bearer capybara").Request("payment-notification");
            try
            {
                _logger.LogInformation($"Notify request for {host} started....");
                var result = await request.PostJsonAsync(new { telegramId = telegramId, value = value });
                if (result.StatusCode == 200)
                    _logger.LogInformation($"Success {host}");
                else
                    _logger.LogError($"Error {host}, status code: {result.StatusCode}");
            }
            catch (Exception  exception)
            {
                _logger.LogError(exception.GetAllMessagesIntoString());
            }
        }

        return new Handler<bool>(true);
    }
}