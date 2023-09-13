using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SoulCoderzAPI.Data;
using SoulCoderzAPI.Data.DTOs;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private MySQLContext _context;
  private IMapper _mapper;

  public UserController(MySQLContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddUser([FromBody] CreateUserDto userDto)
  {
    User user = _mapper.Map<User>(userDto);

    _context.Users.Add(user);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
  }

  [HttpGet]
  public IEnumerable<ReadUserDto> GetAllUsers(
    [FromQuery] int skip = 0,
    [FromQuery] int take = 10,
    [FromQuery] string? username = null
  )
  {
    if (username != null)
    {
      return _mapper.Map<List<ReadUserDto>>(_context.Users.Where((user) => user.Username == username));
    }

    return _mapper.Map<List<ReadUserDto>>(_context.Users.Skip(skip).Take(take));
  }

  [HttpGet("{id}")]
  public IActionResult GetUserById(int id)
  {
    User? user = _context.Users.FirstOrDefault((user) => user.Id == id);

    if (user == null)
    {
      return NotFound();
    }

    ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);

    return Ok(userDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
  {
    User? user = _context.Users.FirstOrDefault((user) => user.Id == id);

    if (user == null)
    {
      return NotFound();
    }

    _mapper.Map(userDto, user);
    _context.SaveChanges();

    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult PatchUser(int id, JsonPatchDocument<UpdateUserDto> patch)
  {
    User? user = _context.Users.FirstOrDefault((user) => user.Id == id);

    if (user == null)
    {
      return NotFound();
    }

    UpdateUserDto userToUpdate = _mapper.Map<UpdateUserDto>(user);
    patch.ApplyTo(userToUpdate, ModelState);

    if (!TryValidateModel(userToUpdate))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(userToUpdate, user);
    _context.SaveChanges();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteUser(int id)
  {
    User? user = _context.Users.FirstOrDefault((user) => user.Id == id);

    if (user == null)
    {
      return NotFound();
    }

    _context.Remove(user);
    _context.SaveChanges();

    return NoContent();
  }
}