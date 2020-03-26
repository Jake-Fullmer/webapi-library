using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi_library.DB;
using webapi_library.Models;

namespace webapi_library.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LibrariesController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Library>> Read()
    {
      try
      {
        return Ok(FakeDB.libraries);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Library> Create([FromBody] Library newLibrary)
    {
      try
      {
        FakeDB.libraries.Add(newLibrary);
        return Created($"api/libraries/{newLibrary.Id}", newLibrary);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Library> Update(string id, [FromBody] Library updatedLibrary)
    {
      try
      {
        Library libraryToUpdate = FakeDB.libraries.Find(l => l.Id == id);
        if (libraryToUpdate == null)
        {
          throw new Exception();
        }
        libraryToUpdate.Name = updatedLibrary.Name;
        libraryToUpdate.Address = updatedLibrary.Address;
        return Ok(libraryToUpdate);
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
        Library libraryToDelete = FakeDB.libraries.Find(l => l.Id == id);
        if (libraryToDelete == null)
        {
          throw new Exception("Bad ID");
        }
        FakeDB.libraries.Remove(libraryToDelete);
        return Ok("Successfully Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




  }
}