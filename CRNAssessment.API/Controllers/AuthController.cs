using CRNAssessment.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRNAssessment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (request.Username != "admin" ||
            request.Password != "admin123")
        {
            return Unauthorized();
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("ThisIsMyVeryLongSecretKeyForJwtAuthentication2026"));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, request.Username!)
    };

        var token = new JwtSecurityToken(
            issuer: "CRNAssessment",
            audience: "CRNAssessmentUsers",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        var jwtToken = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(jwtToken);
    }
}