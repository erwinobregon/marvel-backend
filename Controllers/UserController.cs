using ApiMarvel.Model;
using ApiMarvel.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await userService.Register(userDto))
            {
                return Ok(userDto);
            }
            else return BadRequest();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await userService.Login(userDto))
            {
                return Ok(userDto);
            }
            else return Unauthorized();

        }
    }
}
