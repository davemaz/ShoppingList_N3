using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public enum Priority
    {
        [Display(Name = "It Can Wait.")]
        ItCanWait = 0,
        [Display(Name = "Need It Soon")]
        NeedItSoon = 1,
        [Display(Name = "Get It Now!")]
        GetItNow = 2
    }
}
