using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExamesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exame>>> Listar()
    {
        return await _context.Exames
            .Include(e => e.Paciente)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exame>> BuscarPorId(int id)
    {
        var exame = await _context.Exames
            .Include(e => e.Paciente)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (exame == null)
            return NotFound();

        return exame;
    }

    [HttpPost]
    public async Task<ActionResult<Exame>> Criar(Exame exame)
    {
        _context.Exames.Add(exame);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = exame.Id }, exame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Exame exame)
    {
        if (id != exame.Id)
            return BadRequest();

        _context.Entry(exame).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var exame = await _context.Exames.FindAsync(id);

        if (exame == null)
            return NotFound();

        _context.Exames.Remove(exame);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}