namespace EventHub.API.Models;

public class Certificado
{
    public int Id { get; set; }
    public int ParticipanteId { get; set; }
    public int EventoId { get; set; }
    public int CargaHorariaTotal { get; set; }
    public string CodigoValidacao { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
}