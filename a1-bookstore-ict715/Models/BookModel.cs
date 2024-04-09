// using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace a1_bookstore_ict715.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter a title for this book")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please select the genre of this book")]
        [Display(Name = "Genre")]
        [ForeignKey("GenreName")]
        public string? GenreName { get; set; } // Foreign key
        public GenreModel? Genre { get; set; }
        [Required(ErrorMessage = "Please enter a brief description of this book")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a name(s) for the author(s) of this book")]
        [Display(Name = "Author(s)")]
        public string? Authors { get; set; }
        [Required(ErrorMessage ="Please enter the price of this book")]
        [Range(0, 5000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "What was the publish date of this book (YEAR/MO/DA")]
        [Display(Name = "Date Published")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? PublishDate { get; set; }
    }
}
