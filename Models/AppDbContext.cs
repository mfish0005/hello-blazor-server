using Microsoft.EntityFrameworkCore;
using System;

namespace HelloBlazor.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>().HasData(
              new
              {
                  Id = "2345",
                  Name = "Jane Doe",
              }
            );
        }
    }
}
