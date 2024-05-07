using AutoMapper;
using Logic.Database.Models;
using Logic.Logic.Interface;
using logic.Model.Dto.Tariff;
using Logic.Model.Result.Shared;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Logic.Logic;

public class TariffLogic : BaseLogic, ITariffLogic
{
    #region Service constructor and injected dependencies

    private readonly ILogger<TariffLogic> _logger;
    private readonly IMapper _mapper;
    private readonly IRepository<Tariff> _tariffRepository;
    private readonly IRepository<PeriodUnit> _periodUnitRepository;

    public TariffLogic(ILogger<TariffLogic> logger, IMapper mapper, IRepository<Tariff> tariffRepository,
        IRepository<PeriodUnit> periodUnitRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _tariffRepository = tariffRepository;
        _periodUnitRepository = periodUnitRepository;
    }

    #endregion

    public async Task<HandlerResult> Add(AddTariffRequestModel model)
    {
        try
        {
            // Map the request model to the Tariff entity
            var tariff = _mapper.Map<Tariff>(model);

            // Add the new tariff to the database
            await _tariffRepository.AddAsync(tariff);

            // Save changes to the database
            await _tariffRepository.SaveAsync();

            const string message = "Successfully added a new tariff.";
            _logger.LogInformation(message);

            return HandlerResult.Success(message);
        }
        catch (Exception ex)
        {
            const string message = "An error occurred while adding a new tariff.";
            _logger.LogError(ex, message);
            
            return HandlerResult.Failure(ex);
        }
    }

    public async Task<HandlerResult<List<PeriodUnitResponseModel>>> GetPeriodUnits()
    {
        try
        {
            var periodUnits = await _periodUnitRepository.Where(p => true).ToListAsync();

            _logger.LogInformation("Successfully fetched period units");

            return HandlerResult<List<PeriodUnitResponseModel>>.Success(
                _mapper.Map<List<PeriodUnitResponseModel>>(periodUnits));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching period units");
            return HandlerResult<List<PeriodUnitResponseModel>>.Failure(ex);
        }
    }

    public async Task<HandlerResult<List<TariffResponseModel>>> GetAll()
    {
        try
        {
            var tariffs = await _tariffRepository.Where(t => true).Include(t => t.PeriodUnit).ToListAsync();

            var tariffResponseModels = _mapper.Map<List<TariffResponseModel>>(tariffs);

            _logger.LogInformation("Successfully fetched all tariffs");

            return HandlerResult<List<TariffResponseModel>>.Success(tariffResponseModels);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching all tariffs");
            return HandlerResult<List<TariffResponseModel>>.Failure(ex);
        }
    }

    public async Task<HandlerResult<TariffResponseModel>> Get(Guid id)
    {
        try
        {
            var tariff = await _tariffRepository.Where(t => t.Id == id).Include(t => t.PeriodUnit)
                .FirstOrDefaultAsync();

            if (tariff is null)
            {
                const string message = "Tariff does not exist.";
                _logger.LogInformation(message);
                return HandlerResult<TariffResponseModel>.Failure(message);
            }

            var tariffResponseModel = _mapper.Map<TariffResponseModel>(tariff);

            _logger.LogInformation("Successfully fetched tariff");

            return HandlerResult<TariffResponseModel>.Success(tariffResponseModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching tariff");
            return HandlerResult<TariffResponseModel>.Failure(ex);
        }
    }
    
    public async Task<HandlerResult<bool>> Delete(Guid id)
    {
        try
        {
            var tariff = await _tariffRepository.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (tariff is null)
            {
                const string message = "Tariff does not exist.";
                _logger.LogInformation(message);
                return HandlerResult<bool>.Failure(message);
            }

            _tariffRepository.Delete(tariff);
            await _tariffRepository.SaveAsync();

            _logger.LogInformation("Successfully deleted tariff");

            return HandlerResult<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting tariff");
            return HandlerResult<bool>.Failure(ex);
        }
    }
    
    public async Task<HandlerResult<List<TariffResponseModel>>> GetAllPersonal()
    {
        try
        {
            var tariffs = await _tariffRepository.Where(t => t.MinUserCount == 1 && t.MaxUserCount == 1).Include(t => t.PeriodUnit).ToListAsync();

            var tariffResponseModels = _mapper.Map<List<TariffResponseModel>>(tariffs);

            _logger.LogInformation("Successfully fetched all personal tariffs");

            return HandlerResult<List<TariffResponseModel>>.Success(tariffResponseModels);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching all personal tariffs");
            return HandlerResult<List<TariffResponseModel>>.Failure(ex);
        }
    }
}
