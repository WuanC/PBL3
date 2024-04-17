using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }


        [Required]
        
        public int Price {  get; set; }
    }
}
