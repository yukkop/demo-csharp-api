using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Logic.Database.Models;
using Logic.Enum;
using Logic.Externsions;
using Logic.Logic.Interface;
using Logic.Model.Dto;
using Logic.Model.Dto.User;
using Logic.Model.Result.Shared;
using Logic.Model.Result.UserLogic;
using Logic.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Logic.Logic;

public class UserLogic : BaseLogic, IUserLogic
{
    private IMapper _mapper;
    private IRepository<User> _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IRepository<UserPayment> _userPaymentRepository;

    public UserLogic(IMapper mapper, IRepository<User> userRepository, UserManager<User> userManager,
        RoleManager<Role> roleManager, IConfiguration configuration, IRepository<UserPayment> userPaymentRepository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _userRepository = userRepository;
        _configuration = configuration;
        _userPaymentRepository = userPaymentRepository;
        _roleManager = roleManager;
    }
    
    public async Task<HandlerResult> Delete(Guid id)
    {
        var user = await _userRepository.Where(u => u.Id == id).Include(u => u.PaymentHistory).FirstOrDefaultAsync();
        if (user == null) return HandlerResult.Failure(new Exception("User not found"));
        
        if (user.PaymentHistory is null)
            return HandlerResult.Failure(new Exception("Payment history not found"));
        await _userPaymentRepository.DeleteRangeSaveAsync(user.PaymentHistory);
        
        await _userRepository.DeleteSaveAsync(user);
        return HandlerResult.Success("Success");
    }

    public async Task<IGetTockenResult> GetToken(LoginRequestModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return new GetTockenUnauthorizeResult();
        var token = GenerateJwtToken(user);
        return new GetTockenJWTTokenResult(token);

    }

    public async Task<List<User>> GetAll()
    {
        var users = await _userManager.Users.ToListAsync();
        return users;
    }

    public async Task<HandlerResult<string>> Register(RegisterRequestModel model, UserRoleEnum role)
    {
        // Create a new User object with the provided data
        var user = new User
        {
            UserName = model.Username,
            Email = model.Email,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Create the user using the UserManager
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded) {
            if (result.Errors.First().Code == "DuplicateUserName")
                return HandlerResult<string>.Failure("duplicate name, try chose another");
            return HandlerResult<string>.Failure(result.Errors.First().Code);
        };
        // Assign the "User" role to the new user
        var roleResult = await _userManager.AddToRoleAsync(user, role);
        if (!roleResult.Succeeded) return HandlerResult<string>.Failure(roleResult.Errors.First().Code);
        // If the user creation and role assignment are successful, generate a JWT token and return it
        var token = GenerateJwtToken(user);
        return HandlerResult<string>.Success(token);

        // If there are errors during role assignment, add the errors to the ModelState
        // foreach (var error in roleResult.Errors)
        // {
        //     ModelState.AddModelError(string.Empty, error.Description);
        // }

        // If there are errors during user creation, add the errors to the ModelState
        // foreach (var error in result.Errors)
        // {
        //     ModelState.AddModelError(string.Empty, error.Description);
        // }
    }

    private string GenerateJwtToken2(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            // new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Version, "1.0.1"), // TODO change every time when change token
                // Add any other required claims
            }),
            Expires = DateTime.UtcNow.AddHours(2), // Customize the token expiration time
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private async Task EnsureRoleExists(string name)
    {
        if (!await _roleManager.RoleExistsAsync(name))
        {
            var role = new Role()
            {
                Name = name
            };

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to create role '{name}'.");
            }
        }
    }
    

}