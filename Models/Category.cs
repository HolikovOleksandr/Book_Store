using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Category
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(0, 100)]
        [DisplayName("Display Order")] 
        public int DisplayOrder { get; set; }
    }
}
