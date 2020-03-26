using System;
using System.Collections.Generic;
using console_library.Models;
using Microsoft.AspNetCore.Mvc;
using webapi_library.DB;

namespace webapi_library.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Read()
    {
      try
      {
        return Ok(FakeDB.books);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        FakeDB.books.Add(newBook);
        return Created($"api/books/{newBook.Id}", newBook);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Book> Update(string id, [FromBody] Book updatedBook)
    {
      try
      {
        Book bookToUpdate = FakeDB.books.Find(b => b.Id == id);
        if (bookToUpdate == null)
        {
          throw new Exception();
        }
        bookToUpdate.Title = updatedBook.Title;
        bookToUpdate.Author = updatedBook.Author;
        return Ok(bookToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Book bookToDelete = FakeDB.books.Find(b => b.Id == id);
        if (bookToDelete == null)
        {
          throw new Exception("Bad ID");
        }
        FakeDB.books.Remove(bookToDelete);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}