using Common.Model;
using System.ComponentModel.DataAnnotations;

namespace Application.Usecases.Users.Commands
{
    public class LoginModel : BaseModel
    {
        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [MaxLength(16)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }

    public class SendVerificationCodeModel : BaseModel
    {
        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}