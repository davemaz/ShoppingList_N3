using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class NoteModel
    {
        public int NoteId { get; set; }

        public int ShoppingListItemId { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Body { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifieDateTimeOffset { get; set; }

        public override string ToString()
        {
            return $"[{NoteId}]";
        }
    }
}
