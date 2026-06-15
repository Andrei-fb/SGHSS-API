using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize(Roles = "Administrador")]
public class InternacoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public InternacoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Internacao>>> Listar()
    {
        return await _context.Internacoes
            .Include(i => i.Paciente)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Internacao>> BuscarPorId(int id)
    {
        var internacao = await _context.Internacoes
            .Include(i => i.Paciente)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (internacao == null)
            return NotFound();

        return internacao;
    }

    [HttpPost]
    public async Task<ActionResult<Internacao>> Criar(Internacao internacao)
    {
        _context.Internacoes.Add(internacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = internacao.Id }, internacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Internacao internacao)
    {
        if (id != internacao.Id)
            return BadRequest();

        _context.Entry(internacao).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var internacao = await _context.Internacoes.FindAsync(id);

        if (internacao == null)
            return NotFound();

        _context.Internacoes.Remove(internacao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}