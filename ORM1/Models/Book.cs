using System.ComponentModel.DataAnnotations;

namespace ORM1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public decimal Price { get; set; }

        public int PublishYear { get; set; }
    }
}