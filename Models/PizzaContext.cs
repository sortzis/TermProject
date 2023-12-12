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
                    PhoneNumber = "5559874563",
                    MenuId = 1
                },
                new Loyalty
                {
                    ID = 2,
                    FirstName = "Robert",
                    LastName = "Robertson",
                    City = "Olympia",
                    State = "Washington",
                    Email = "rrobertson@gmail.com",
                    PhoneNumber = "5559875823",
                    MenuId = 3
                },
                new Loyalty
                {
                    ID = 3,
                    FirstName = "Richard",
                    LastName = "Richardson",
                    City = "Portland",
                    State = "Oregon",
                    Email = "richierich@gmail.com",
                    PhoneNumber = "5552584596",
                    MenuId = 2
                }
                );
            modelBuilder.Entity<Menu>().HasData(
                new Menu 
                {
                    MenuId = 1,
                    Name = "Breadstix",
                    LoyaltyTier = "Newbie"
                },
                new Menu
                {
                    MenuId = 2,
                    Name = "Wings",
                    LoyaltyTier = "Novice"
                },
                new Menu
                {
                    MenuId = 3,
                    Name = "Pizza",
                    LoyaltyTier = "Veteran"
                }
                );
        }

        public DbSet<TermProject.Models.Menu>? Menu { get; set; }
    }
}
