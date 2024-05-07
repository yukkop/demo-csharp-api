using AutoMapper;
using Logic.Database.Models;
using logic.Model.Dto.Bundles;
using Logic.Model.Dto.Certificate;
using logic.Model.Dto.Employee;
using Logic.Model.Dto.Employer;
using Logic.Model.Dto.Payment;
using Logic.Model.Dto.Region;
using Logic.Model.Dto.Server;
using logic.Model.Dto.Tariff;
using Logic.Model.Dto.VpnUser;

namespace Logic;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        UsersTypeMapping();
        TariffsTypeMapping();
        PeriodUnitsTypeMapping();
        ServersTypeMapping();
        RegionsTypeMapping();
        CertificatesTypeMapping();
        EmployersTypeMapping(); 
        BundlesTypeMapping();
        EmployeeAccessesTypeMapping();
        Payment();
    }

    private void UsersTypeMapping()
    {
        CreateMap<VpnUser, VpnUserShortResponseModel>();
        CreateMap<VpnUser, VpnUserResponseModel>()
            // .ForMember(dest => dest.ReceiveBytes, opt =>
            //     opt.MapFrom(src => src.CertificateHistory
            //         .Select(item => item.Certificate.ReceiveBytes)
            //         .Aggregate(src.Certificate.ReceiveBytes, (sum, receiveBytes) => sum + receiveBytes))
            // )
            // .ForMember(dest => dest.TransmitBytes, opt =>
            //     opt.MapFrom(src => src.CertificateHistory
            //         .Select(item => item.Certificate.TransmitBytes)
            //         .Aggregate(src.Certificate.TransmitBytes, (sum, transmitBytes) => sum + transmitBytes))
            // )
            // TODO 
            .ForMember(dest => dest.TransmitBytes, opt =>
                opt.MapFrom(src => src.Certificate == null ? 0 : src.Certificate.TransmitBytes))
            .ForMember(dest => dest.ReceiveBytes, opt =>
                opt.MapFrom(src => src.Certificate == null ? 0 : src.Certificate.ReceiveBytes))
            .ForMember(dest => dest.IsEmployeeAccessActive, opt =>
                opt.MapFrom(src => src.EmployeeAccesses.SingleOrDefault() != null && (src.EmployeeAccesses.Single().Bundle.Balance > 0 ? true : false)))
            .ForMember(dest => dest.Employer, opt =>
                opt.MapFrom(src => src.EmployeeAccesses.SingleOrDefault() != null ? src.EmployeeAccesses.Single().Bundle.Employer : null));

        CreateMap<AddVpnUserRequestModel, VpnUser>()
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.DateOfLastBalanceDecrease, opt => opt.MapFrom(src => DateTime.Now))     
            .ForMember(dest => dest.FreePeriodUsed, opt => opt.MapFrom(src => false));
    }
    
    private void TariffsTypeMapping()
    {
        CreateMap<Tariff, TariffResponseModel>();
        
        CreateMap<AddTariffRequestModel, Tariff>();
    }
    
    private void PeriodUnitsTypeMapping()
    {
        CreateMap<PeriodUnit, PeriodUnitResponseModel>();
    }

    private void ServersTypeMapping()
    {
        CreateMap<Server, ServerResponseModel>();

        CreateMap<AddServerRequestModel, Server>()
            .ForMember(dest => dest.CountUsers, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.Region, opt => opt.Ignore());
    }

    private void RegionsTypeMapping()
    {
        CreateMap<Region, RegionResponseModel>();

        CreateMap<AddRegionRequestModel, Region>();
    }

    private void CertificatesTypeMapping()
    {
        CreateMap<Certificate, CertificateResponseModel>();
    }

    private void EmployersTypeMapping()
    {
        CreateMap<AddEmployerRequestModel, Employer>();
        CreateMap<Employer, EmployerResponseModel>();
    }

    private void BundlesTypeMapping()
    {
        CreateMap<Bundle, BundleResponseModel>();
    }

    private void EmployeeAccessesTypeMapping()
    {
        CreateMap<EmployeeAccess, EmployeeAccessRequestModel>();
    }

    private void Payment() {
        CreateMap<Payment, PaymentItemResponseModel>()
            .ForMember(dest => dest.IdempotenceKey, opt => opt.MapFrom(src => src.IdempotenceKey.ToString()))
            .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.IdempotenceKey.ToString()));

        CreateMap<Payment, PaymentUserHistoryItemModel>();
        
        CreateMap<Payment, PaymentHistoryItemModel>()
            .ForMember(dest => dest.VpnUser, opt => opt.MapFrom(src => src.UserPayments.Any() ? src.UserPayments.Single().User.VpnUser : null)) ;
        
    }
}