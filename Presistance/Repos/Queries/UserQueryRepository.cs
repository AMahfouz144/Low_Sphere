

using Application.Reposirories.Presistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Presistance.Core;

namespace Presistence.Repositories.Queries
{
    public class UserQueryRepository :Repository<User>,IUserQueryRepository
    {
        public UserQueryRepository( IServiceProvider provider):base(provider)
        {
        }

        public async Task<bool> EmailIsExist(string email, Guid id = new Guid())
        {
            return await store.Where(u => u.Email == email && u.Id != id).AnyAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await store.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByEmail(string email)
        {
            //return await dbContext.Users
            //      .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            return await store.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            //return dbContext.Users.ToList();

            return await store.ToListAsync();
        }

    }
}