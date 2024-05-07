using System.ComponentModel.DataAnnotations;

namespace Logic.Model.Dto.User;

public class RegisterRequestModel
{
    [Required]
    public string? Username { get; set; }
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}