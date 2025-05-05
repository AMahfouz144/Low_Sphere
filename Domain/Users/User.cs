
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Common;

namespace Domain.Users
{
    [Table(nameof(User))]
    public class User:IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string HashedPassword { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Mobile { get; set; } = string.Empty;
        public int Age { get; set; }
        [MaxLength(10)]
        public UserRole Role { get; set; }
        public int Level { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
