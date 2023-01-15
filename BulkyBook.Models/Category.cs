using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Name"), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public string DisplayOrder { get; set; }
        [Display(Name = "Time Created")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
