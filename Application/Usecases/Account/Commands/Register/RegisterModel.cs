

using Common.Model;

namespace Application.Usecases.Account.Commands
{
    public class RegisterModel: BaseModel
    {
        public string Email { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
