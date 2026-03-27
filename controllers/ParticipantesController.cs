using EventHub.API.Models;
using EventHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipantesController : ControllerBase
{
    private readonly SistemaService _service;

    public ParticipantesController(SistemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Participante>> Get()
    {
        return Ok(_service.ListarParticipantes());
    }

    [HttpPost("cadastro")]
    public ActionResult<Participante> Cadastro(Participante participante)
    {
        try
        {
            var novo = _service.CadastrarParticipante(participante);
            return Ok(novo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var participante = _service.Login(request.Email, request.Senha);

        if (participante is null)
            return Unauthorized("E-mail ou senha inválidos.");

        return Ok(participante);
    }

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var excluido = _service.ExcluirParticipante(id);

    if (!excluido)
        return NotFound("Participante não encontrado.");

    return NoContent();
}
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}