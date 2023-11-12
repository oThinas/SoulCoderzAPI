using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoulCoderzAPI.Data;
using SoulCoderzAPI.Data.DTOs;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FeedbackController : ControllerBase
{
  private MySQLContext _context;
  private IMapper _mapper;

  public FeedbackController(MySQLContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult SendFeedback([FromBody] CreateFeedbackDto feedbackDto)
  {
    Feedback feedback = _mapper.Map<Feedback>(feedbackDto);

    _context.Feedbacks.Add(feedback);

    _context.SaveChanges();

    return Ok(_mapper.Map<List<ReadFeedbackDto>>(_context.Feedbacks));
  }

  [HttpGet]
  public IEnumerable<ReadFeedbackDto> GetAllFeedbacks()
  {
    return _mapper.Map<List<ReadFeedbackDto>>(_context.Feedbacks);
  }
}