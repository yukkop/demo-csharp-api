using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Logic.Database.Models;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using Logic.Model.Dto.Server;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;

namespace Logic.Logic;

public class ServerLogic : BaseLogic, IServerLogic
{
    #region Service constructor and injected dependencies
    private readonly ILogger<ServerLogic> _logger;
    private IMapper _mapper;
    private IRepository<Server> _serverRepository;
    private IRepository<Region> _regionRepository;

    public ServerLogic(ILogger<ServerLogic> logger, IMapper mapper, IRepository<Server> serverRepository, IRepository<Region> regionRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _serverRepository = serverRepository;
        _regionRepository = regionRepository;
    }
    #endregion

    public async Task<IList<ServerResponseModel>> List()
    {
        return _mapper.Map<List<ServerResponseModel>>(await _serverRepository.Where(s => true).Include(s => s.Region).ToListAsync());
    }

    public async Task<IHandler<ServerResponseModel>> Get(Guid id)
    {
        var server = await _serverRepository.Where(s => s.Id == id).Include(s => s.Region).FirstOrDefaultAsync();
        if (server is null)
            return new HandlerException<ServerResponseModel>(_logger, $"Server ({id}) does not exist");

        return _mapper.Map<ServerResponseModel>(server).Wrap();
    }

    public async Task<IHandler<bool>> Add(AddServerRequestModel model)
    {
        var region = await _regionRepository.Where(r => r.Id == model.RegionId).FirstOrDefaultAsync();
        if (region is null)
            return new HandlerException<bool>(_logger, "Region does not exist in database");

        var server = _mapper.Map<Server>(model);

        await _serverRepository.AddSaveAsync(server);

        return true.Wrap();
    }

    public async Task<IHandler<bool>> Delete(Guid id)
    {
        var server = await _serverRepository.Where(s => s.Id == id).Include(s => s.Region).FirstOrDefaultAsync();
        if (server is null)
            return new HandlerException<bool>(_logger, $"Server ({id}) does not exist");

        await _serverRepository.DeleteSaveAsync(server);
        return true.Wrap();
    }
}