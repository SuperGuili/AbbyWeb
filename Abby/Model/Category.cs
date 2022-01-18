using System.ComponentModel.DataAnnotations;

namespace Abby.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 999, ErrorMessage = "Display Order must be between 1 and 999")]
        public string DisplayOrder { get; set; }
    }
}
