using System.ComponentModel.DataAnnotations;
using Logic.Library;
using Logic.Model.Dto.Certificate;
using Logic.Model.Dto.Employer;
using Logic.Model.Dto.Region;

namespace Logic.Model.Dto.VpnUser;

public class VpnUserResponseModel
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public int Balance { get; set; }
    [Required]
    public bool IsEmployeeAccessActive { get; set; }
    public EmployerResponseModel? Employer { get; set; }
    [Required]
    public bool FreePeriodUsed { get; set; }
    public RegionResponseModel? Region { get; set; }
    public CertificateResponseModel? Certificate  { get; set; }
    [Required]
    public ulong ReceiveBytes { get; set; }
    [Required]
    public ulong TransmitBytes { get; set; }

    public override bool Equals(object obj)
    {
        return Comparator.Equals<VpnUserResponseModel>(this, obj as VpnUserResponseModel);
    }
}