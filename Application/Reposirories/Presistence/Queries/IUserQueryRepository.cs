using Application.Interfaces;
using Domain.Users;


namespace Application.Reposirories.Presistence
{
    public interface IUserQueryRepository:IRepository<User>
    {
        Task<bool> EmailIsExist(string email, Guid id = new Guid());
        Task<User> GetUserByEmail(string email);
        Task<User> GetById(Guid id);
        Task<List<User>> GetUsers();
    }
}