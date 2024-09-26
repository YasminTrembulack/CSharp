using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Globalization;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using Models;
using Musify.DTO;
using Musify.Services;
using Repositories;

[ApiController]
[Route("auth")]
public class AuthController(IUserRepository repo, IConfiguration configuration) : ControllerBase
{   
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody]LoginPayload login)
    {
        var user = await repo.VerifyLogin(login.Username, login.Password);

        if (user is null)
            return Unauthorized();

        var token = TokenService.GenerateToken(user, configuration);

        return Ok(new LoginResponse(token));
    }

    [HttpPost("register")]
    // [Authorize(Roles = "ADM")]
    [AllowAnonymous]
    public async Task<ActionResult> Register(UserDTO payload)
    {
        var exists = await repo.GetByUsername(payload.Username);
        if(exists != null)
            BadRequest("Username already in use");

        DateTime birth = DateTime.ParseExact(payload.BirthDate, 
                                         "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);

        var user = new User
        {
            Username = payload.Username,
            Password = payload.Password,
            BirthDate = birth,
            Role = payload.Role
        };
        User new_user = await repo.Add(user);
        
        return Ok(new CreateUserResponde( "User created with success.", new_user.Id));
    }
}