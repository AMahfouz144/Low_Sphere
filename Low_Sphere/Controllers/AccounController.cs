using Application.Usecases.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistance.Core;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccounController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<string> Login([FromBody] LoginModel model, [FromServices] ILoginUserCommand login) // Must send username & password
        {
            var res = await login.Excute(model);
            return res;
        }

        [HttpPost("SendVerificationCode")]
        public async Task<bool> SendVerificationCode([FromBody] SendVerificationCodeModel model, [FromServices] ISendVerificationCodeCommand command)
        {
            var res = await command.Excute(model);
            return res;
        }

        [HttpPost("Register")]
        public async Task<Guid> Register([FromBody] SignUpModel model, [FromServices] ISignUpCommand signUp)
        {
            var res = await signUp.Excute(model);
            return res;
        }
        [HttpGet("LoggedInUsers")]
        public async Task<IActionResult> GetLoggedInUsers([FromServices] AppDbContext context)
        {
            var users = await context.LoginRecords
                .Include(lr => lr.User)
                .OrderByDescending(lr => lr.LoginTime)
                .Select(lr => new {
                    lr.User.Id,
                    lr.User.FullName,
                    lr.LoginTime
                })
                .ToListAsync();

            return Ok(users);
        }


    }
}
