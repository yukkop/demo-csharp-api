using System.ComponentModel.DataAnnotations;
using Logic.Model.Dto.Certificate;
using Logic.Model.Dto.Employer;
using Logic.Model.Dto.Region;

namespace Logic.Model.Dto.VpnUser;

public class VpnUserShortResponseModel
{
    [Required] public Guid Id { get; set; }
    [Required] public long TelegramId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required] public int Balance { get; set; }
    [Required] public bool IsEmployeeAccessActive { get; set; }
    public EmployerResponseModel? Employer { get; set; }
}