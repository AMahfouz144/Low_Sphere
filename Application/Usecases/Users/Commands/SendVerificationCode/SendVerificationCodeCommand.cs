using Application.Reposirories.Presistence;
using Common.Exceptions;

namespace Application.Usecases.Users.Commands
{
    public class SendVerificationCodeCommand : ISendVerificationCodeCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        //private readonly ICreateOtpCommand createOtpCommand;

        //public SendVerificationCodeCommand(IUserQueryRepository userQueryRepository, ICreateOtpCommand createOtpCommand)
        public SendVerificationCodeCommand(IUserQueryRepository userQueryRepository)
        {
            this.userQueryRepository = userQueryRepository;
            //this.createOtpCommand = createOtpCommand;
        }

        public async Task<bool> Excute(SendVerificationCodeModel model)
        {
            model.Validate();

            var exist = await userQueryRepository.EmailIsExist(model.Email);
            if (exist)
                throw new BusinessException("Email is exist", "EmailIsExist");

            //await createOtpCommand.Execute(model.Email, 15);

            //Later we will Send Otp Via mail

            return exist;
        }
    }
}
