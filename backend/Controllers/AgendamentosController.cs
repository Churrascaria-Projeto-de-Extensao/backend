using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerBase
{
    private readonly AppDbContext _context;

    public AgendamentosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var agendamentos = await _context.Agendamentos
            .Include(a => a.Cliente)
            .ToListAsync();

        return Ok(agendamentos);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarAgendamentoDto dto)
    {
        bool conflito = await _context.Agendamentos
            .AnyAsync(a => dto.DataHoraInicio < a.DataHoraFim && dto.DataHoraFim > a.DataHoraInicio);

        if (conflito)
            return BadRequest("O horário selecionado já está ocupado.");

        var agendamento = new Agendamento
        {
            DataHoraInicio = dto.DataHoraInicio,
            DataHoraFim = dto.DataHoraFim,
            CepLocal = dto.CepLocal,
            EnderecoCompleto = dto.EnderecoCompleto,
            NumeroConvidados = dto.NumeroConvidados,
            ClienteId = dto.ClienteId,
            Status = StatusAgendamento.Pendente,
            ValorTotal = 0
        };

        _context.Agendamentos.Add(agendamento);
        await _context.SaveChangesAsync();

        return Ok(agendamento);
    }
}