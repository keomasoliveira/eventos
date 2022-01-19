using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    public readonly EventosContext _context;

    public EventosController(EventosContext context)
    {
      _context = context;

    }



    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetbyId(int id)
    {
      return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }


  }
}
