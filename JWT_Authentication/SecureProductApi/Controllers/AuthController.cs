using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//in auth controller create jwt
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;// Used to read values from appsettings.json
    public AuthController(IConfiguration config) //dependency injection
    {
        _config = config; 
    }

    [HttpPost("login")]//This method runs when client calls:
    public IActionResult Login()
    {
        //Server CREATES JWT Token
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "student"),
            new Claim(ClaimTypes.Role, "Admin")
        };

       //Secret key-- used to SIGN token
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["JwtKey"]!)
        );

        var token = new JwtSecurityToken(
            issuer: "SecureApi",
            audience: "SecureApiUsers",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials:
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256)//sign the token using secret key
        );
           //Sending token to client
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)//Converts token object → JWT string
        });
    }
}