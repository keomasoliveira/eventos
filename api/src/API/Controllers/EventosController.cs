using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


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
    public IEnumerable<Eventos> Get()
    {
      return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Eventos GetbyId(int id)
    {
      return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }


  }
}
