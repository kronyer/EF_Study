using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Study.Model;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    [Required]
    [MaxLength(20)]
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public virtual BookDetail BookDetail { get; set; } //why should i use virtual?
    [ForeignKey("Publisher")]
    public int Publisher_Id { get; set; }
    public virtual Publisher Publisher { get; set; }
    public List<Author> Authors { get; set; }

}
