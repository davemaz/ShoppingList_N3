using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListItemCreateModel
    {
        [Required]
        [MaxLength(8000)]
        public string Content { get; set; }

        //created separate file for enum.
        public Priority Priority { get; set; }
        
    }
}
