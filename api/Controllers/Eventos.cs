using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Models;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    public readonly DataContext _context;

    public EventosController(DataContext context)
    {
      _context = context;

    }



    [HttpGet]
    public IEnumerable<EventosList> Get()
    {
      return _context.EventosList;
    }

    [HttpGet("{id}")]
    public EventosList GetbyId(int id)
    {
      return _context.EventosList.FirstOrDefault(evento => evento.EventoId == id);
    }


  }
}
