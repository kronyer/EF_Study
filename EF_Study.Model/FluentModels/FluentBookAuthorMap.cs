using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Study.Model;

public class FluentBookAuthorMap
{
    public int Book_Id { get; set; }
    public int Author_Id { get; set; }
    public FluentBook Book { get; set; }
    public FluentAuthor Author { get; set; }
}
