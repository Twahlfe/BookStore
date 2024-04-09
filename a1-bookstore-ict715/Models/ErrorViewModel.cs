using System.ComponentModel.DataAnnotations;

namespace a1_bookstore_ict715.Models
{
    public class ErrorViewModel
    {
        [Key]
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}