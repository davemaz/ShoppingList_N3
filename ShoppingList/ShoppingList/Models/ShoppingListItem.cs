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

        public Priority Priority { get; set; }
        
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
