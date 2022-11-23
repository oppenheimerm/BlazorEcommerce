using System.ComponentModel.DataAnnotations;

namespace BEC.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Category code must be 4 characters long")]
        public string CategoryCode { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Maximum 25 character limit")]
        public string Title { get; set; }
    }
}