using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Study.Model;

[Table("Categories")]
public class Cateogory
{
    [Key]
    public int GenreId { get; set; }
    [Column("Name")]
    [Required]
    public string CategoryName { get; set; }
    //public int DisplayOrder { get; set; }
}
