using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.Controllers;

[Route("api/health")]
[ApiController]
[AllowAnonymous]
public class HealthController : ControllerBase
{
    private readonly HealthCheckService _healthCheckService;

    public HealthController(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var report = await _healthCheckService.CheckHealthAsync();

        return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode(503, report);
    }

    [HttpGet("token-check")]
    public IActionResult SomeAction()
    {
        var authorizationHeader = Request.Headers["Authorization"].ToString();

        JwtSecurityToken jwtToken;
        if (authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Create a JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            // Read the token
            jwtToken = handler.ReadJwtToken(token);

            var audiences = string.Join(", ", jwtToken.Audiences);

            return Ok(new
            {
                authorizationHeader, jwtToken.Subject, jwtToken.Issuer,
                audiences, jwtToken.Claims
            });
        }

        return Ok(new { authorizationHeader });
    }
}