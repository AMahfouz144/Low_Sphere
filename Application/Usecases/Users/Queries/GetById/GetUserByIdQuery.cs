using Application.Reposirories.Presistence;
using Domain.Users;
using Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Queries.GetById
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IUserQueryRepository userQueryRepository;
        public GetUserByIdQuery(IUserQueryRepository userQueryRepository)
        {
            this.userQueryRepository = userQueryRepository;
        }

        public async Task<UserDto> Execute(Guid id)
        {
            //Validete Id
            if (id == default)
                throw new ValidationsException("Invaild Id", "Invaild Id");

            //Get from DB
            var user =await userQueryRepository.GetById(id);

            //Check if user exist or not
            if (user == null)
                throw new EntityNotFoundException<User>(id.ToString());

            //Map DB object to Dto
            UserDto result = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Mobile = user.Mobile,
                FullName = user.FullName,
                Role=user.Role,
                CreatedAt = user.CreatedAt,
            };

            //return
            return result;
        }
    }
}
