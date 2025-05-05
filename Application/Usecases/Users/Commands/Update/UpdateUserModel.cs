using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Usecases.Users.Commands
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        //public string NID { get; set; }
    }
}
