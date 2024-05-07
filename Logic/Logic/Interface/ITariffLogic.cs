using logic.Model.Dto.Tariff;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface ITariffLogic: IBaseLogic
{
    public Task<HandlerResult> Add(AddTariffRequestModel model);

    public Task<HandlerResult<List<PeriodUnitResponseModel>>> GetPeriodUnits();
    
    public Task<HandlerResult<List<TariffResponseModel>>> GetAll();

    public Task<HandlerResult<List<TariffResponseModel>>> GetAllPersonal();
}