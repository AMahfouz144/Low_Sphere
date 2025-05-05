using Common.Model;
using Domain.Enums;


namespace Application.Usecases.Users.Commands
{
    public class AddUserModel: BaseModel
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Mobile { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }

        //public DateTime CreatedAt { get; set; }
    }
}