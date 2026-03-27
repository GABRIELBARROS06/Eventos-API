using EventHub.API.Models;

namespace EventHub.API.Services;

public class SistemaService
{
    private readonly List<Evento> _eventos = [];
    private readonly List<Participante> _participantes = [];
    private readonly List<Inscricao> _inscricoes = [];
    private readonly List<Certificado> _certificados = [];

    private int _eventoId = 1;
    private int _participanteId = 1;
    private int _inscricaoId = 1;
    private int _certificadoId = 1; 



    public List<Evento> ListarEventos() => _eventos;

    public Evento CriarEvento(Evento evento)
    {
        evento.Id = _eventoId++;
        _eventos.Add(evento);
        return evento;
    }

    public bool AtualizarEvento(int id, Evento eventoAtualizado)
{
    var evento = BuscarEventoPorId(id);
    if (evento is null) return false;

    evento.Titulo = eventoAtualizado.Titulo;
    evento.Descricao = eventoAtualizado.Descricao;
    evento.DataInicio = eventoAtualizado.DataInicio;
    evento.DataFim = eventoAtualizado.DataFim;
    evento.Local = eventoAtualizado.Local;

    return true;
}

public bool ExcluirEvento(int id)
{
    var evento = BuscarEventoPorId(id);
    if (evento is null) return false;

    _eventos.Remove(evento);
    return true;
}

public bool ExcluirParticipante(int id)
{
    var participante = _participantes.FirstOrDefault(p => p.Id == id);
    if (participante is null) return false;

    _participantes.Remove(participante);
    return true;
}

    public List<Participante> ListarParticipantes() => _participantes;

    public Participante CadastrarParticipante(Participante participante)
    {
        if (_participantes.Any(p => p.Email == participante.Email))
            throw new Exception("E-mail já cadastrado.");

        participante.Id = _participanteId++;
        _participantes.Add(participante);
        return participante;
    }

    public Participante? Login(string email, string senha)
    {
        return _participantes.FirstOrDefault(p => p.Email == email && p.Senha == senha);
    }

    public Inscricao RealizarInscricao(int participanteId, int eventoId)
    {
        var participante = _participantes.FirstOrDefault(p => p.Id == participanteId);
        if (participante is null)
            throw new Exception("Participante não encontrado.");

        var evento = _eventos.FirstOrDefault(e => e.Id == eventoId);
        if (evento is null)
            throw new Exception("Evento não encontrado.");

        if (_inscricoes.Any(i => i.ParticipanteId == participanteId && i.EventoId == eventoId))
            throw new Exception("Já está inscrito nesse evento.");

        var inscricao = new Inscricao
        {
            Id = _inscricaoId++,
            ParticipanteId = participanteId,
            EventoId = eventoId
        };

        _inscricoes.Add(inscricao);
        return inscricao;
    }

    public bool CancelarInscricao(int id)
{
    var inscricao = _inscricoes.FirstOrDefault(i => i.Id == id);
    if (inscricao is null) return false;

    _inscricoes.Remove(inscricao);
    return true;
}

    public Certificado GerarCertificado(int participanteId, int eventoId, int cargaHoraria)
{
    var participante = _participantes.FirstOrDefault(p => p.Id == participanteId);
    if (participante is null)
        throw new Exception("Participante não encontrado.");

    var evento = _eventos.FirstOrDefault(e => e.Id == eventoId);
    if (evento is null)
        throw new Exception("Evento não encontrado.");

    var inscricao = _inscricoes.FirstOrDefault(i =>
        i.ParticipanteId == participanteId &&
        i.EventoId == eventoId);

    if (inscricao is null)
        throw new Exception("Inscrição não encontrada para esse participante nesse evento.");

    var certificadoExistente = _certificados.FirstOrDefault(c =>
        c.ParticipanteId == participanteId &&
        c.EventoId == eventoId);

    if (certificadoExistente is not null)
        throw new Exception("Certificado já foi gerado para esse participante nesse evento.");

    var certificado = new Certificado
    {
        Id = _certificadoId++,
        ParticipanteId = participanteId,
        EventoId = eventoId,
        CargaHorariaTotal = cargaHoraria,
        CodigoValidacao = Guid.NewGuid().ToString("N")[..8].ToUpper(),
        DataEmissao = DateTime.Now
    };

    _certificados.Add(certificado);
    return certificado;
}

public List<Certificado> ListarCertificados()
{
    return _certificados;
}

public Certificado? BuscarCertificadoPorCodigo(string codigo)
{
    return _certificados.FirstOrDefault(c => c.CodigoValidacao == codigo);
}

public Evento? BuscarEventoPorId(int id)
{
    return _eventos.FirstOrDefault(e => e.Id == id);
}

    public List<Inscricao> ListarInscricoes() => _inscricoes;
}