using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListItem
    {
        [Key]
        public int ShoppingListItemModelId { get; set; }
        
        public int ShoppingListId { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Content { get; set; }

        public enum Priority
        {
            [Display(Name = "It Can Wait.")]
            ItCanWait = 0,
            [Display(Name = "Need It Soon")]
            NeedItSoon = 1,
            [Display(Name = "Get It Now!")]
            GetItNow = 2
        }

        [MaxLength(8000)]
        public string Note { get; set; }

        public bool IsChecked { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString()
        {
            return $"[{ShoppingListItemModelId}]";
        }
        
        public virtual ShoppingList ShoppingListModel { get; set; }

    }
}
