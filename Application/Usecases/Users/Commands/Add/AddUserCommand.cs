using Application.Interfaces;
using Application.Reposirories.Presistence;
using Application.Reposirories.Presistence.Repositories;
using Domain.Users;
using Common.Exceptions;
using System;
using System.Threading.Tasks;
using Application.Common.MyFramwork;
namespace Application.Usecases.Users.Commands
{
    public class AddUserCommand : IAddUserCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IUserRepository userRepository;
        private readonly IDatabaseService databaseService;
        private readonly IHashingService hashingService;
        public AddUserCommand(IUserQueryRepository userQueryRepository, IUserRepository userRepository, IDatabaseService databaseService)
        {
            this.userQueryRepository = userQueryRepository;
            this.userRepository = userRepository;
            this.databaseService = databaseService;
            this.hashingService = new HashingService();
        }

        public async Task<Guid> Execute(AddUserModel model)
        {
            //S1 - Validation on model data 

            //S2 - Check if email exist or not 
            var exist =await userQueryRepository.EmailIsExist(model.Email);
            if (exist)
                throw new BusinessException("Email is exist", "EmailIsExist");
            //check Mobile number 
            var _validation = new HandlerUser();
            if (!_validation.IsMobileNumber(model.Mobile))
            {
                throw new BusinessException("MObile Number Is not valid", "Should write correct number");
            }
            if (model.Password==null)
            {
                throw new BusinessException("Password Required", "must enter yout password");
            }
            //S3 - Create Object & Add to DB
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Mobile = model.Mobile,
                FullName = model.FullName,
                CreatedAt= DateTime.Now,
            };
            var HashedPassword = hashingService.Create(model.Password,user.Id.ToString());
            user.HashedPassword = HashedPassword;

            userRepository.Add(user);
            await databaseService.SaveChangesAsync();

            //S4 - return id
            return user.Id;
        }
    }
}