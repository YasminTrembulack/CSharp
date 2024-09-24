using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using Microsoft.AspNetCore.Authorization;
using Models;
using Musify.Services;
using Repositories;

[ApiController]
[Route("auth")]
public class AuthController(IUserRepository repo) : ControllerBase
{   
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody]LoginDTO login)
    {
        var user = await repo.Get(login.Username, login.Password);

        if (user is null)
            return Unauthorized();

        var token = TokenService.GenerateToken(user);

        return Ok(token);
    }

    [HttpGet("register")]
    [Authorize]
    public async Task<ActionResult> Register(User payload)
    {

        var user = await repo.Get("yas", "123");

        return Ok("null");
    }

    public record LoginDTO
    (
        string Username,
        string Password
    );
}