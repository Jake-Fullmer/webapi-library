using System;
using System.Collections.Generic;
using console_library.Models;
using webapi_library.DB;
using webapi_library.Models;

namespace webapi_library.Services
{
  class MainService
  {
    public List<Message> Messages { get; set; } = new List<Message>();
    public void AddItemToMessages()
    {
      for (int i = 0; i < FakeDB.books.Count; i++)
      {
        var item = FakeDB.books[i];
        if (item.Available == true)
        {
          Messages.Add(new Message($"{i + 1}) {item.Title} - {item.Author}"));
        }
      }
    }
    private Book ValidateBook(string selection, List<Book> booklist)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > booklist.Count)
      {
        return null;
      }
      return booklist[bookIndex - 1];
    }
    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(selection, FakeDB.books);
      if (selectedBook == null)
      {
        Console.Clear();
        Console.Beep();
        Console.WriteLine($"Invalid Selection!!!\n");
        return;
      }
      else
      {
        selectedBook.Available = false;
        // _checkedOut.Add(selectedBook);
        // _books.Remove(selectedBook);
        // Console.Clear();
        Console.WriteLine($"You have checked out Book: {selectedBook.Title} by {selectedBook.Author} \n");
      }
    }
  }
}