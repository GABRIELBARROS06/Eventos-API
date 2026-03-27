using EventHub.API.Models;
using EventHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificadosController : ControllerBase
{
    private readonly SistemaService _service;

    public CertificadosController(SistemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Certificado>> Get()
    {
        return Ok(_service.ListarCertificados());
    }

    [HttpGet("{codigo}")]
    public IActionResult GetByCodigo(string codigo)
    {
        var certificado = _service.BuscarCertificadoPorCodigo(codigo);

        if (certificado is null)
            return NotFound("Certificado não encontrado.");

        return Ok(certificado);
    }

    [HttpPost("gerar")]
    public IActionResult Gerar([FromBody] CertificadoRequest request)
    {
        try
        {
            var certificado = _service.GerarCertificado(
                request.ParticipanteId,
                request.EventoId,
                request.CargaHorariaTotal
            );

            return Ok(certificado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class CertificadoRequest
{
    public int ParticipanteId { get; set; }
    public int EventoId { get; set; }
    public int CargaHorariaTotal { get; set; }
}