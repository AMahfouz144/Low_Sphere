using Application.Interfaces;
using Application.Reposirories.Presistence.Repositories;
using Application.Reposirories.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Exceptions;
using Domain.Users;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    internal class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IUserRepository userRepository;
        private readonly IDatabaseService databaseService;
        public UpdateUserCommand(IUserQueryRepository userQueryRepository, IUserRepository userRepository, IDatabaseService databaseService)
        {
            this.userQueryRepository = userQueryRepository;
            this.userRepository = userRepository;
            this.databaseService = databaseService;
        }
        public async Task<bool> Execute(UpdateUserModel model)
        {

            var exist =await userQueryRepository.EmailIsExist(model.Email,model.Id);
            if (exist)
                throw new BusinessException("Email is exist", "EmailIsExist");

            var user =await userQueryRepository.GetById(model.Id);
            if (user == null)
                throw new BusinessException("Email not exist", "EmailIsn'tExist");

            if (!new HandlerUser().IsMobileNumber(model.Mobile))
                throw new BusinessException("Mobile number isn't valid", "Mobile number isn't valid");

            //if (!new HandlerUser().IsNID(model.NID))
            //    throw new BusinessException("NID number isn't valid", "NID number isn't valid");

            user.Email = model.Email;
            user.Mobile = model.Mobile;
            //user.Name = model.Name;
            //user.NID = model.NID;

            userRepository.Update(user);
            databaseService.SaveChanges();
            return true;
        }
    }
}
