using Application.Usecases.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
