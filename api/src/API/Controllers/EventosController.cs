using System;
using System.Threading.Tasks;
using API.Application;
using API.Application.Contract;
using API.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    public readonly IEventosService _eventoService;

    public EventosController(IEventosService eventoService)
    {
      _eventoService = eventoService;

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var eventos = await _eventoService.GetAllEventosAsync(true);
        if (eventos == null) return NotFound("Nenhum Evento encontrado");
        return Ok(eventos);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
         $"Erro ao tentar Recuperar eventos. Erro: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetbyId(int id)
    {
      try
      {
        var eventos = await _eventoService.GetEventoByIdAsync(id, true);
        if (eventos == null) return NotFound("Evento por Id não encontrado.");
        return Ok(eventos);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
        $"Erro ao tentar Recuperar eventos. Erro: {ex.Message}");
      }
    }
    [HttpGet("{tema}")]
    public async Task<IActionResult> GetbyTema(string tema)
    {
      try
      {
        var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
        if (eventos == null) return NotFound("Eventos por tema não encontrados.");
        return Ok(eventos);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
        $"Erro ao tentar Recuperar eventos. Erro: {ex.Message}");
      }
    }
    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
      try
      {
        var eventos = await _eventoService.AddEvento(model);
        if (eventos == null) return BadRequest("Erro ao tentar adicionar Evento.");
        return Ok(eventos);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
         $"Erro ao tentar Recuperar eventos. Erro: {ex.Message}");
      }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
      try
      {
        var eventos = await _eventoService.UpdateEvento(id, model);
        if (eventos == null) return BadRequest("Erro ao tentar adicionar Evento.");
        return Ok(eventos);
      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
        $"Erro ao tentar Atualizar os eventos. Erro: {ex.Message}");
      }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        return await _eventoService.DeleteEvento(id) ?
        Ok("Deletado") :
        BadRequest("Evento não deletado");

      }
      catch (Exception ex)
      {

        return this.StatusCode(StatusCodes.Status500InternalServerError,
        $"Erro ao tentar Recuperar eventos. Erro: {ex.Message}");
      }
    }
  }
}
