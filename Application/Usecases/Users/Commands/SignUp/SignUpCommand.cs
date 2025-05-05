using Application.Common.MyFramwork;
using Application.Interfaces;
using Application.Reposirories.Presistence;
using Application.Reposirories.Presistence.Repositories;
using Common.Exceptions;
using Domain.Users;


namespace Application.Usecases.Users.Commands
{
    public class SignUpCommand : ISignUpCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IUserRepository userRepository;
        private readonly IDatabaseService databaseService;
        private readonly IHashingService hashingService;
        //private readonly IVerifyOtpCommand verifyOtpCommand;
        public SignUpCommand(IUserQueryRepository userQueryRepository, IUserRepository userRepository, IDatabaseService databaseService, IHashingService hashingService)
        {
            this.userQueryRepository = userQueryRepository;
            this.userRepository = userRepository;
            this.databaseService = databaseService;
            this.hashingService = hashingService;
            //this.verifyOtpCommand = verifyOtpCommand;
        }

        public async Task<Guid> Excute(SignUpModel model)
        {
            model.Validate();

            var exist = await userQueryRepository.EmailIsExist(model.Email);
            if (exist)
                throw new BusinessException("Email is exist", "EmailIsExist");

            //await verifyOtpCommand.Execute(model.Email, model.VerificationCode);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Mobile = model.Mobile,
                FullName = model.FullName,
                CreatedAt = DateTime.UtcNow,
                Role = model.Role,

            };

            user.HashedPassword = hashingService.Create(model.Password, user.Id.ToString());

            userRepository.Add(user);
            await databaseService.SaveChangesAsync();

            return user.Id;
        }
    }
}