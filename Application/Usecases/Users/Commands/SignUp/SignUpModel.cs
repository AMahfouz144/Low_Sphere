
using Common.Model;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Usecases.Users.Commands
{
    public class SignUpModel : BaseModel
    {
        [MaxLength(256)]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [MaxLength(16)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }
        public UserRole Role { get; set; }
        public string Mobile { get; set; }

        [MaxLength(8)]
        [MinLength(4)]
        [Required(AllowEmptyStrings = false)]
        public string VerificationCode { get; set; }

    }
}