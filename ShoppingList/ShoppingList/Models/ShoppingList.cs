using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListModelId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString()
        {
            return $"[{ShoppingListModelId}] {Name}";
        }

        public virtual ICollection<ShoppingListItem> ShoppingListItemModels { get; set; }
    }
}