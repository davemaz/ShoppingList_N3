using System;
using System.Collections.Generic;

namespace ShoppingList.Models
{
    public class ShoppingListModel
    {
        public int ShoppingListId { get; set; }
        
        public int UserId { get; set; }

        public  string Name { get; set; }

        public string Color { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        //may or may not need ToString or public virtual collection: To Be Determined.

        public override string ToString()
        {
            return $"[{ShoppingListId}] {Name}";
        }

        public virtual ICollection<ShoppingListItemModel>ShoppingListItemModels { get; set; }
    }
}
