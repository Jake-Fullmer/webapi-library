using System.Collections.Generic;
using webapi_library.Models;

namespace webapi_library.DB
{
  static class FakeDB
  {
    public static List<Library> libraries = new List<Library>(){
    new Library("Adrian", "311 Main St 97901")
  };
  }
}