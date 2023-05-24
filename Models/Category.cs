using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Display order must be betwen 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
