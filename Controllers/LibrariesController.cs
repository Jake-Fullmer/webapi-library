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
    public ActionResult<IEnumerable<Library>> Get()
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
    public ActionResult<Library> Post([FromBody] Library newLibrary)
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





  }
}