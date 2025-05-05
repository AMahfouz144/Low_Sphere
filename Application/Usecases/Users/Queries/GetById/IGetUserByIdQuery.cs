using System;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Queries
{
    public interface IGetUserByIdQuery
    {
       Task <UserDto> Execute(Guid id);
    }
}