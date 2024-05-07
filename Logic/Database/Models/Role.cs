using Microsoft.AspNetCore.Identity;

namespace Logic.Database.Models;

public class Role : IdentityRole<Guid>, IBase
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}