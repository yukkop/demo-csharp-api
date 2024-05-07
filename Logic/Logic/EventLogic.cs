using Logic.Database.Models;
using Logic.ExternalConnection.TelegramSubscribers.Repositories;
using Logic.Logic.Interface;
using Logic.Model.Dto;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;

namespace Logic.Logic;

public class EventLogic : BaseLogic, IEventLogic
{
    #region Service constructor and injected dependencies
    private readonly IRepository<User> _userRepository;
    private readonly TelegramAgentRepository _telegramAgentRepository;
    public EventLogic(TelegramAgentRepository telegramAgentRepository, IRepository<User> userRepository)
    {
        _userRepository = userRepository;
        _telegramAgentRepository = telegramAgentRepository;
    }
    #endregion

    public async Task<IHandler<bool>> DirectTelegramNotify(DirectTelegramNotifyRequestModel model)
    {
        await _telegramAgentRepository.Notify(model.telegramIds, model.message);
        return new Handler<bool>(true);
    }
}