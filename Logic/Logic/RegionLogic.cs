using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Logic.Database.Models;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using Logic.Model.Dto.Region;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;

namespace Logic.Logic;

public class RegionLogic : BaseLogic, IRegionLogic
{
    #region Service constructor and injected dependencies
    private IMapper _mapper;
    private IRepository<Region> _regionRepository;
    private ILogger<Region> _logger; 

    public RegionLogic(IMapper mapper, IRepository<Region> regionRepository, ILogger<Region> logger)
    {
        _mapper = mapper;
        _regionRepository = regionRepository;
        _logger = logger;
    }
    #endregion

    public async Task<IHandler<bool>> Delete(Guid id)
    {
        var region = await _regionRepository.Where(r => r.Id == id).FirstOrDefaultAsync();
        if (region == null)
            return new HandlerException<bool>(_logger, $"Region id does not exist");
        await _regionRepository.DeleteSaveAsync(region);

        return new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> Add(AddRegionRequestModel model)
    {
        var region = _mapper.Map<Region>(model);
        await _regionRepository.AddSaveAsync(region);

        return true.Wrap();
    }

    public async Task<IList<RegionResponseModel>> List()
    {
        var regions = await _regionRepository.Where(r => true).ToListAsync();
        return _mapper.Map<List<RegionResponseModel>>(regions);
    }

    public async Task<IHandler<RegionResponseModel>> Get(Guid id)
    {
        var region = await _regionRepository.Where(r => r.Id == id).FirstOrDefaultAsync();
        if (region is null) 
            return new HandlerException<RegionResponseModel>(_logger, $"Region ({id}) does not exist");

        return _mapper.Map<RegionResponseModel>(region).Wrap();
    }
}