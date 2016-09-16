using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public enum Priority
    {
        [Display(Name = "It Can Wait.")]
        Low = 0,
        [Display(Name = "Need It Soon.")]
        Moderate = 1,
        [Display(Name = "Get It Now!")]
        High = 2

    }
}