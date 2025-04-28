using Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Reposirories.Presistence
{
    public interface IUserQueryRepository
    {
        Task<bool> EmailIsExist(string email, Guid id = new Guid());
        Task<User> GetUserByEmail(string email);
        Task<User> GetById(Guid id);
        Task<List<User>> GetUsers();
    }
}