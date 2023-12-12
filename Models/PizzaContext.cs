using TermProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }
        public DbSet<Loyalty> Loyalties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loyalty>().HasData(
                new Loyalty
                {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Johnson",
                    City = "Seattle",
                    State = "Washington",
                    Email = "jjohnson@gmail.com",
                    PhoneNumber = "5559874563"
                },
                new Loyalty
                {
                    ID = 2,
                    FirstName = "Robert",
                    LastName = "Robertson",
                    City = "Olympia",
                    State = "Washington",
                    Email = "rrobertson@gmail.com",
                    PhoneNumber = "5559875823"
                },
                new Loyalty
                {
                    ID = 3,
                    FirstName = "Richard",
                    LastName = "Richardson",
                    City = "Portland",
                    State = "Oregon",
                    Email = "richierich@gmail.com",
                    PhoneNumber = "5552584596"
                }
                );
        }
    }
}
