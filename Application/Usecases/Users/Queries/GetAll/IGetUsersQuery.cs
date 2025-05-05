using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Queries.GetAll
{
    public interface IGetUsersQuery
    {
        Task<List<UserDto>> Excute ();
    }
}
