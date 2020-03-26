using System.ComponentModel.DataAnnotations;

namespace console_library.Models
{
  public class Book
  {
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Author { get; set; }
    public bool Available { get; set; }

    public Book(string title, string author)
    {
      Title = title;
      Author = author;
      Available = true;
    }
  }
}