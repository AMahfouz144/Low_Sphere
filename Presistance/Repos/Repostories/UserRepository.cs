

using Application.Reposirories.Presistence.Repositories;
using Domain.Users;
using Presistance.Core;

namespace Presistence.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext dbContext;
        public UserRepository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public void Add(User user)
        {
            dbContext.Users.Add(user);  
        }

        public void Delete(User user) 
        {
            dbContext.Users.Remove(user);
        }

        public void Update(User user)
        {
            dbContext.Users.Update(user);
        }
    }
}