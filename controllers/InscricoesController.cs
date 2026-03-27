using EventHub.API.Models;
using EventHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InscricoesController : ControllerBase
{
    private readonly SistemaService _service;

    public InscricoesController(SistemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Inscricao>> Get()
    {
        return Ok(_service.ListarInscricoes());
    }

    [HttpPost]
    public IActionResult Post([FromBody] InscricaoRequest request)
    {
        try
        {
            var inscricao = _service.RealizarInscricao(request.ParticipanteId, request.EventoId);
            return Ok(inscricao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var cancelado = _service.CancelarInscricao(id);

    if (!cancelado)
        return NotFound("Inscrição não encontrada.");

    return NoContent();
}
}

public class InscricaoRequest
{
    public int ParticipanteId { get; set; }
    public int EventoId { get; set; }
}