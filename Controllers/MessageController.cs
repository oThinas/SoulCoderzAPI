using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using SoulCoderzAPI.Data;
using SoulCoderzAPI.Data.DTOs;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
  private MySQLContext _context;
  private IMapper _mapper;

  public MessageController(MySQLContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }
  
  [HttpPost]
  public async Task<IActionResult> SendMessageAsync([FromBody] CreateMessageDto messageDto)
  {
    Models.Message message = _mapper.Map<Models.Message>(messageDto);

    _context.Messages.Add(message);

    /* 
      Aqui ficaria a lógica para se comunicar com a OpenAI e retornar a resposta do assistente virtual.
      Porém, ninguém na equipe possui créditos para utilizar a API, então a resposta está fixada.
      Para criar uma conta com créditos é necessário um número de telefone, então não foi possível fazer essa integração.

      var api = new OpenAIClient("sk-apiKey");
      var chatRequest = new ChatRequest(message, Model.Davinci);
      var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
     */

    Models.Message apiMessage = new Models.Message
    {
      Role = Enums.RoleType.ASSISTANT,
      Content = "Você está falando com a API do SoulCoderz! Seus créditos estão zerados :("
    };

    _context.Messages.Add(apiMessage);

    _context.SaveChanges();

    return Ok(_mapper.Map<List<ReadMessageDto>>(_context.Messages));
  }

  [HttpGet]
  public IEnumerable<ReadMessageDto> GetAllMessages()
  {
    return _mapper.Map<List<ReadMessageDto>>(_context.Messages);
  }

  [HttpDelete]
  public IActionResult DeleteAllMessages()
  {
    _context.Messages.RemoveRange(_context.Messages);
    _context.SaveChanges();

    return Ok();
  }
}