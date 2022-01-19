using System;
using System.Threading.Tasks;
using API.Application.Contract;
using API.Domain;
using API.Persistence;

namespace API.Application
{
  public class EventoService : APIService
  {
    private readonly GeralPersist _geralPersist;
    private readonly EventoPersist _eventoPersist;
    public EventoService(GeralPersist geralPersist, EventoPersist eventoPersist)
    {
      _eventoPersist = eventoPersist;
      _geralPersist = geralPersist;

    }
    public async Task<Evento> AddEvento(Evento model)
    {
      try
      {
        _geralPersist.Add<Evento>(model);
        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (System.Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }


    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
      try
      {
        var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
        if (evento == null) return null;

        model.Id = evento.Id;
        _geralPersist.Update(model);
        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (System.Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
    public async Task<bool> DeleteEvento(int eventoId)
    {
      try
      {
        var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
        if (evento == null) throw new Exception("Evento para delete nao foi encontrado.");


        _geralPersist.Delete<Evento>(evento);

        return await _geralPersist.SaveChangesAsync();
      }
      catch (System.Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includeAtracao = false)
    {
      try
      {
        var eventos = await _eventoPersist.GetAllEventosAsync(includeAtracao);
        if (eventos == null) return null;
        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);

      }
    }

    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includeAtracao = false)
    {
      try
      {
        var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includeAtracao);
        if (eventos == null) return null;
        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);

      }
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao = false)
    {
      try
      {
        var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includeAtracao);
        if (eventos == null) return null;
        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);

      }
    }

  }
}
