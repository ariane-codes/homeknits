using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKnits.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Rating { get; set; }
        public string? ReviewText { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        [ForeignKey("User")]
        public IdentityUser? UserID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}
