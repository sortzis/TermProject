using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Menu
    {
        [Display(Name = "Menu ID")]
        public int MenuId { get; set; }

        [Display(Name = "Food Item")]
        public string? Name { get; set; }

        [Display(Name = "Loyalty Tier")]
        public string? LoyaltyTier { get; set; }
    }
}
