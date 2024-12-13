using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Study.Model;

public class BookAuthorMap
{
    [ForeignKey("Book")]
    public int Book_Id { get; set; }
    [ForeignKey("Author")]
    public int Author_Id { get; set; }
    public virtual Book Book { get; set; }
    public virtual Author Author { get; set; }
}
