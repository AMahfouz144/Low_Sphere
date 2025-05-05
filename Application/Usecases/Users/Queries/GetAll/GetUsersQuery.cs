using Application.Reposirories.Presistence;


namespace Application.Usecases.Users.Queries.GetAll
{
    internal class GetUsersQuery : IGetUsersQuery
    {
        private readonly IUserQueryRepository userQueryRepository;
        public GetUsersQuery(IUserQueryRepository userQueryRepository)
        {

            this.userQueryRepository = userQueryRepository;
        }
        public async Task<List<UserDto>> Excute()
        {
            var users = await userQueryRepository.GetUsers();
            if (users == null)
                throw new Exception("Users Empty");

            var result = new List<UserDto>();

            foreach (var user in users)
            {
                result.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Mobile = user.Mobile,
                    Password = user.HashedPassword,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt,
                });
            }
            return result;
        }
    }
}
