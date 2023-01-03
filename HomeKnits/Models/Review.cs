using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKnits.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }

        [ForeignKey("Product")]
        public Guid ProductID { get; set; }

        [ForeignKey("User")]
        public IdentityUser UserID { get; set; }
    }
}
