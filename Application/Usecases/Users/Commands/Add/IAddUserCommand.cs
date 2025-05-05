using System;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    public interface IAddUserCommand
    {
        Task<Guid> Execute(AddUserModel model);
    }
}