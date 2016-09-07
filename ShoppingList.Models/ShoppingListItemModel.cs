using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListItemModel
    {
        public int ShoppingListItemId { get; set; }

        public int ShoppingListId { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Content { get; set; }

        public enum Priority
        {
            [Display (Name= "It Can Wait.")]
            ItCanWait = 0,
            [Display (Name = "Need It Soon")]
            NeedItSoon = 1,
            [Display (Name = "Get It Now!")]
            GetItNow = 2
        }

        public bool IsChecked { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


        //may or may not need to string and navigation property.
        public override string ToString()
        {
            return $"[{ShoppingListId}]";
        }

        public virtual ShoppingListModel ShoppingListModel { get; set; }
        
    }
}