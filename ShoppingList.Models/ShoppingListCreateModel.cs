using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListCreateModel
    {
        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"[New] {Name}";
        }
    }
}
