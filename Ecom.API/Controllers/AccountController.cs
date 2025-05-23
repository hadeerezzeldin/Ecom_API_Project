using AutoMapper;
using Ecom.Core.DTO.Auth;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork work;
        private readonly IMapper map;

        public AccountController(IUnitOfWork work , IMapper map)
        {
            this.work = work;
            this.map = map;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await work.Auth.RegisterAsync(registerDTO);
            if (result != "Register Done")
            {
                return BadRequest(result);
            }
                return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await work.Auth.LoginAsync(loginDTO);
            if (result == null)
            {
                return BadRequest("Invalid login attempt.");
            }
            Response.Cookies.Append("token", result, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.Now.AddDays(3)
            });
            return Ok(result);
        }
    }
}
