using Microsoft.AspNetCore.Mvc;
using EventHub.API.Models;
using EventHub.API.Services;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly SistemaService _service;

    public EventosController(SistemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Evento>> Get()
    {
        return Ok(_service.ListarEventos());
    }

    [HttpPost]
    public ActionResult<Evento> Post(Evento evento)
    {
        var novo = _service.CriarEvento(evento);
        return Ok(novo);
    }

    [HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var evento = _service.BuscarEventoPorId(id);

    if (evento is null)
        return NotFound("Evento não encontrado.");

    return Ok(evento);
}

[HttpPut("{id}")]
public IActionResult Put(int id, Evento evento)
{
    var atualizado = _service.AtualizarEvento(id, evento);

    if (!atualizado)
        return NotFound("Evento não encontrado.");

    return NoContent();
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var excluido = _service.ExcluirEvento(id);

    if (!excluido)
        return NotFound("Evento não encontrado.");

    return NoContent();
}
}