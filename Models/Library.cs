using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using console_library.Models;

namespace webapi_library.Models
{
  public class Library
  {
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Address { get; set; }
    public string Id { get; set; }
    private List<Book> _books { get; set; }
    private List<Book> _checkedOut { get; set; }
    public Library()
    {
      Id = Guid.NewGuid().ToString();
    }
    public Library(string name, string address)
    {
      Name = name;
      Address = address;
      Id = Guid.NewGuid().ToString();
      _books = new List<Book>();
      _checkedOut = new List<Book>();
    }
  }

}