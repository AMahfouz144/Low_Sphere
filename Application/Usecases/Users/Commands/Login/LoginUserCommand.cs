using Application.Common.MyFramwork;
using Application.Reposirories.Presistence;
using Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Usecases.Users.Commands
{
    public class LoginUserCommand : ILoginUserCommand
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IHashingService hashingService;
        private readonly JwtConfiguration jwtConfiguration;
        public LoginUserCommand(IUserQueryRepository userQueryRepository, IHashingService hashingService, JwtConfiguration jwtConfiguration)
        {
            this.userQueryRepository = userQueryRepository;
            this.hashingService = hashingService;
            this.jwtConfiguration = jwtConfiguration;
        }

        public async Task<string> Excute(LoginModel model)
        {
            model.Validate();

            var user = await userQueryRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                throw new BusinessException("Email is not exist", "EmailIsNotExist");
            }

            //in this palce must hash password 
            var isValid = hashingService.Validate(model.Password, user.Id.ToString(), user.HashedPassword);
            if (!isValid)
            {
                throw new BusinessException("Password is not correct", "PasswordIsNotCorrect");
            }

            // create token
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Fullname", user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var token = GenerateAccessToken(claims, DateTime.UtcNow.AddMinutes(20));

            return token;
        }

        private string GenerateAccessToken(List<Claim> claims, DateTime expireAt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(jwtConfiguration.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature),
                Expires = expireAt
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
