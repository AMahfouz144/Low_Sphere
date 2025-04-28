using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class Entity : IEntity
    {
    }

    public class AuditlessEntity<T> : IEntity<T>
    {
        // Identity 
        [Key]
        public virtual T Id { get; set; }
    }

    public class Entity<T> : IEntity<T>
    {
        // Identity 
        [Key]
        public virtual T Id { get; set; }

        //=========Audit Members============ 
        public DateTime CreatedAt { set; get; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}