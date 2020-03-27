using System.Collections.Generic;
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
        Messages.Add(new Message($"{i + 1}) {item.Title} - {item.Author}"));
      }
    }
    public void Checkout()
    {

    }
  }
}