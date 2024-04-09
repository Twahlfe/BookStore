using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1_bookstore_ict715.Models
{
    public class GenreModel
    {
        [Key]
        public string? GenreId { get; set; }
        
        public string? GenreName { get; set; }
    }
}
