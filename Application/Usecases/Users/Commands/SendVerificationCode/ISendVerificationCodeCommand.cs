using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    public interface ISendVerificationCodeCommand
    {
        Task<bool> Excute(SendVerificationCodeModel model);
    }
}
