using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;

namespace Shopping_List_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthenticationController(IConfiguration config)
    {
        _config = config;
    }

    public record AuthenticationData(string? UserName, string? Password); //class with a parameter.
    public record UserData(int Id, string FirstName, string LastName, string UserName);

    [HttpPost("token")]
    [AllowAnonymous]
    public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
    {
        var user = ValidateCredentials(data); // compare username and password provided by user

        if (user == null)
        {
            return Unauthorized();
        }

        string token = GenerateToken(user); // UserData user // instance of UserData

        return Ok(token);
    }

    private UserData? ValidateCredentials(AuthenticationData data)
    {
        //TEST CODE: REPLACE THIS WITH A CALL TO YOUR AUTH SYSTEM
        if ((CompareValues(data.UserName, "Micheal")) && (CompareValues(data.Password, "Shodammola")))
        {
            return new UserData(1, "Micheal", "Dgreat", data.UserName);
        }

        if ((CompareValues(data.UserName, "Micheal")) && (CompareValues(data.Password, "Shodammola")))
        {
            return new UserData(1, "Mike", "Mic", data.UserName);
        }

        return null;
    }

    private bool CompareValues(string? actual, string expected)
    {
        if (actual != null)
        {
            if (actual == expected) return true;
        }

        return false;
    }


    private string GenerateToken(UserData user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:Secretkey")));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new();
        claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName));
        claims.Add(new(JwtRegisteredClaimNames.GivenName, user.FirstName));
        claims.Add(new(JwtRegisteredClaimNames.FamilyName, user.LastName));


        var token = new JwtSecurityToken(_config.GetValue<string>("Authentication:Issuer"), 
                                                        _config.GetValue<string>("Authentication:Audience"), 
                                                        claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(60), 
                                                        signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
