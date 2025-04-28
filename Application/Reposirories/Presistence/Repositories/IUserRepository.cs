using Domain.Users;
using System.Threading.Tasks;

namespace Application.Reposirories.Presistence.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);

        void Delete(User user);
    }
}