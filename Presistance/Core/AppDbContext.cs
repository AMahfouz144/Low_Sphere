using Application.Usecases.Users.Commands.Login;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Presistence.Core;

namespace Presistance.Core
{
    public class AppDbContext : DbContext
    {
        private string connectionString;
        public IDatabaseServiceOptions options;
        public AppDbContext(IDatabaseServiceOptions options)
        {
            this.options = options;
            this.connectionString = options.ConnectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
      public DbSet<User> Users { get; set; }
      public DbSet<LoginRecord> LoginRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //    .HasIndex(a => a.Email)
            //    .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}