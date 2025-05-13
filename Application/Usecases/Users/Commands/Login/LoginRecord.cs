using Domain.Users;

namespace Application.Usecases.Users.Commands.Login
{
    public class LoginRecord
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } // نفس نوع User.Id
        public DateTime LoginTime { get; set; }

        public User User { get; set; }
    }
}
