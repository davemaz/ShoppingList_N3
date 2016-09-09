using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListModel
    {
        public int ShoppingListId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString()
        {
            return $"[{ShoppingListId}] {Name}";
        }

        public virtual ICollection<ShoppingListItemModel> ShoppingListItemModels { get; set; }
    }
}