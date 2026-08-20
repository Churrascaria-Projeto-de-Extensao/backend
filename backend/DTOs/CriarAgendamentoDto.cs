namespace backend.DTOs;

public class CriarAgendamentoDto
{
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string? CepLocal { get; set; }
    public string? EnderecoCompleto { get; set; }
    public int NumeroConvidados { get; set; }
    public int ClienteId { get; set; }
    public int ServicoId { get; set; }
}