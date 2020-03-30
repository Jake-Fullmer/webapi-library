using System.Collections.Generic;
using console_library.Models;
using webapi_library.Models;

namespace webapi_library.DB
{
  static class FakeDB
  {
    // NOTE Bad practice.  Only using to mock DB
    public static List<Library> libraries = new List<Library>(){
    new Library("Adrian", "311 Main St 97901")};
    public static List<Book> books = new List<Book>(){
    new Book("The Wild West", "Mr. Teacher"),
    new Book("Not Available", "Mr. T")};
  }
}