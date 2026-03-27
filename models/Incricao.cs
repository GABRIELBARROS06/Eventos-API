namespace EventHub.API.Models;

public class Inscricao
{
    public int Id { get; set; }
    public int ParticipanteId { get; set; }
    public int EventoId { get; set; }
    public DateTime DataInscricao { get; set; } = DateTime.Now;
}