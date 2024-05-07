using AutoMapper;
using Logic.Database.Models;
using Logic.Logic.Interface;
using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Logic.Logic;

public class BundleLogic : BaseLogic, IBundleLogic
{
    #region Service constructor and injected dependencies

    private readonly IMapper _mapper;

    private readonly ILogger<BundleLogic> _logger;

    private readonly IRepository<EmployeeAccess> _employeeAccessRepository;
    private readonly IRepository<VpnUser> _vpnUserRepository;
    private readonly IRepository<Bundle> _bundleRepository;
    private readonly IVpnUserLogic _vpnUserLogic;

    public BundleLogic(
        IMapper mapper,
        ILogger<BundleLogic> logger, IRepository<EmployeeAccess> employeeAccessRepository,
        IRepository<Bundle> bundleRepository, IVpnUserLogic vpnUserLogic, IRepository<VpnUser> vpnUserRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _employeeAccessRepository = employeeAccessRepository;
        _bundleRepository = bundleRepository;
        _vpnUserLogic = vpnUserLogic;
        _vpnUserRepository = vpnUserRepository;
    }

    #endregion

    public async Task<IList<EmployeeAccessRequestModel>> GetEmployeeAccesses(Guid bundleId, GetEmployeeFilter filter)
    {
        var employeeAccesses = await _employeeAccessRepository
            .Where(e => e.BundleId == bundleId && filter.IsActivate == false || e.VpnUser != null).ToListAsync();

        return _mapper.Map<List<EmployeeAccessRequestModel>>(employeeAccesses);
    }

    public async Task<IHandler<bool>> DecreaseBalancesAndUpdateTime()
    {
        var accessBundles = await _bundleRepository
            .Where(u => u.Balance > 0).ToListAsync();


        var now = DateTime.Now.ToUniversalTime();
        foreach (var bundle in accessBundles.Where(b => b.LastBalanceDecreaseAt < now.AddDays(-1)))
        {
            bundle.Balance--;
            bundle.LastBalanceDecreaseAt = now;

            if (bundle.Balance != 0) continue;
            foreach (var access in bundle.EmployeeAccesses.Where(access => access.VpnUser != null))
            {
                var exemptResult = await _vpnUserLogic.ExemptCertificate(access.VpnUser!);
                if (exemptResult is HandlerException<bool>)
                    return exemptResult;

                _vpnUserRepository.Update(access.VpnUser!);
            }
        }

        _bundleRepository.UpdateRange(accessBundles);
        await _bundleRepository.SaveAsync();
        return new Handler<bool>(true);
    }
}