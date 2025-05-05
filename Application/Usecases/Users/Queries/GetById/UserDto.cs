using Common.Model;
using Domain.Enums;

namespace Application.Usecases.Users.Queries
{
    public class UserDto : BaseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserRole Role { get; set; }
    }
}