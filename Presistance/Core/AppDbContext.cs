using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Presistence.Core;

namespace Presistance.Core
{
    public class AppDbContext : DbContext
    {
        private string connectionString;
        public AppDbContext()
        {
            this.connectionString = "Data Source=ABDOMAHFOUZ;Database=LawSphere;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        DbSet<User>Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //    .HasIndex(a => a.Email)
            //    .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}