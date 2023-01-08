using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKnits.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public string? Category { get; set; }

        public string? Colour { get; set; }

        public string? Technique { get; set; }

        
        
    }
}
