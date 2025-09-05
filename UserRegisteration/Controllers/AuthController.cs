using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegisteration.DTOs;
using UserRegisteration.Interfaces;

namespace UserRegisteration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }
        // register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            if (result == null) return BadRequest("Email already exisit");
            return Ok(result);
        }
        //login
        [HttpPost("Login")]
        public async Task<IActionResult> Login (LoginUserDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (result == null) return Unauthorized("Invalid credentials.");
            return Ok(result);
        }

    }
}
