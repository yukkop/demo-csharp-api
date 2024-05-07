using Logic.Database.Models;
using Logic.Enum;
using Microsoft.AspNetCore.Identity;

namespace Logic.Externsions;
public static class UserManagerExtensions
{
    public static async Task<IdentityResult> AddToRoleAsync(this UserManager<User> userManager, User user, UserRoleEnum role)
    {
        string roleName = role.ToString();
        return await userManager.AddToRoleAsync(user, roleName);
    }
}