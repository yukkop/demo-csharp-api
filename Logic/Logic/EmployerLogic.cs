using AutoMapper;
using Logic.Database.Models;
using Logic.Enum;
using Logic.ExternalConnection.TelegramSubscribers.Repositories;
using Logic.Logic.Interface;
using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Dto.Employer;
using Logic.Model.Dto.User;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Logic.Logic;

public class EmployerLogic : BaseLogic, IEmployerLogic
{
    #region Service constructor and injected dependencies

    private readonly IMapper _mapper;
    private readonly ILogger<EmployerLogic> _logger;

    private readonly IRepository<Employer> _employerRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Bundle> _bundleRepository;
    private readonly IRepository<EmployeeAccess> _employeeAccessRepository;

    private readonly IUserLogic _userLogic;

    public EmployerLogic(TelegramAgentRepository telegramAgentRepository, IRepository<Employer> employerRepository,
        IMapper mapper, IUserLogic userLogic, IRepository<User> userRepository, ILogger<EmployerLogic> logger,
        IRepository<Bundle> bundleRepository, IRepository<EmployeeAccess> employeeAccessRepository)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
        _userLogic = userLogic;
        _userRepository = userRepository;
        _logger = logger;
        _bundleRepository = bundleRepository;
        _employeeAccessRepository = employeeAccessRepository;
    }

    #endregion

    public async Task<IList<EmployerResponseModel>> GetAll()
    {
        var employers = await _employerRepository.Where(e => true).ToListAsync();
        return _mapper.Map<List<EmployerResponseModel>>(employers);
    }

    public async Task<IHandler<bool>> Add(AddEmployerRequestModel model)
    {
        var employer = _mapper.Map<Employer>(model);

        // generate uniq code to employer
        var code = $"employer-{Guid.NewGuid().ToString()}";
        var answer = await _userLogic.Register(new RegisterRequestModel
            {
                Username = model.Name,
                Email = code,
                Password = "Employer-Default13"
            },
            UserRoleEnum.Employer);
        if (answer.IsSuccessful == false)
            return new HandlerException<bool>(_logger, answer.Message ?? "", LogType.Critical);

        var user = await _userRepository.Where(u => u.Email == code).FirstOrDefaultAsync();
        if (user == null)
            return new HandlerException<bool>(_logger, "usser not created", LogType.Critical);

        employer.User = user;
        await _employerRepository.AddSaveAsync(employer);

        return true.Wrap();
    }

    public async Task<IHandler<bool>> CreateBundle(Guid employerId, int employeesCount)
    {
        var employer = await _employerRepository.Where(e => e.Id == employerId).FirstOrDefaultAsync();
        if (employer == null)
            return new HandlerException<bool>(_logger, "", LogType.Critical);

        var bundleId = Guid.NewGuid();
        var bundle = new Bundle
        {
            Id = bundleId,
            MaxEmployees = employeesCount,
            EmployerId = employerId,
            Balance = 30,
            LastBalanceDecreaseAt = DateTime.Now
        };

        await _bundleRepository.AddSaveAsync(bundle);

        for (var i = 0; i < employeesCount; i++)
        {
            var newEmployeeAccess = new EmployeeAccess()
            {
                BundleId = bundleId,
                Code = Guid.NewGuid(),
                IsDelete = false
            };

            await _employeeAccessRepository.AddAsync(newEmployeeAccess);
        }

        await _employeeAccessRepository.SaveAsync();

        return true.Wrap();
    }

    public async Task<IList<BundleResponseModel>> GetBundles(Guid employerId)
    {
        var bundles = await _bundleRepository.Where(b => b.EmployerId == employerId).ToListAsync();

        return _mapper.Map<List<BundleResponseModel>>(bundles);
    }


    public async Task<IList<EmployeeAccessRequestModel>> GetEmployeeAccesses(Guid employerId, GetEmployeeFilter filter)
    {
        var employeeAccesses = await _employeeAccessRepository
            .Where(e => e.Bundle.EmployerId == employerId && filter.IsActivate == false || e.VpnUser != null).ToListAsync();

        return _mapper.Map<List<EmployeeAccessRequestModel>>(employeeAccesses);
    }
}