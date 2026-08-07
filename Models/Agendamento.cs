using backend.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string CepLocal { get; set; } = string.Empty;
    public string EnderecoCompleto { get; set; } = string.Empty;
    public int NumeroConvidados { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusAgendamento Status { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public int ServicoId { get; set; }
    public Servico Servico { get; set; } = null!;
}

public enum StatusAgendamento
{
    Pendente,
    Confirmado,
    Cancelado,
    Concluido
}