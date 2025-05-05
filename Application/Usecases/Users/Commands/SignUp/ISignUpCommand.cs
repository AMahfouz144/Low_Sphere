
namespace Application.Usecases.Users.Commands
{
    public interface ISignUpCommand
    {
        Task<Guid> Excute(SignUpModel model);
    }
}
