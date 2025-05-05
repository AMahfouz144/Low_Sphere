using Application.Interfaces;
using Application.Reposirories.Presistence.Repositories;
using Application.Reposirories.Presistence;
using System;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IUserRepository userRepository;
        private readonly IDatabaseService databaseService;
        public DeleteUserCommand(IUserQueryRepository userQueryRepository,IUserRepository userRepository,IDatabaseService databaseService)
        {
            this.userQueryRepository = userQueryRepository;
            this.userRepository = userRepository;
            this.databaseService = databaseService;
        }
        public async Task<bool> Excute(Guid id)
        {
            if (id ==default) throw new Exception("ID Is Empty");
            
            var user=await userQueryRepository.GetById(id);
            
            if (user == null) throw new Exception("User Not Exsit");
            
            userRepository.Delete(user);
            databaseService.SaveChanges();
            return true;
        }
    }
}
