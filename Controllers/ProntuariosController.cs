using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize(Roles = "Profissional,Administrador")]
public class ProntuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProntuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Prontuario>>> Listar()
    {
        return await _context.Prontuarios
            .Include(p => p.Consulta)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Prontuario>> BuscarPorId(int id)
    {
        var prontuario = await _context.Prontuarios
            .Include(p => p.Consulta)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prontuario == null)
            return NotFound();

        return prontuario;
    }

    [HttpPost]
    public async Task<ActionResult<Prontuario>> Criar(Prontuario prontuario)
    {
        _context.Prontuarios.Add(prontuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = prontuario.Id }, prontuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Prontuario prontuario)
    {
        if (id != prontuario.Id)
            return BadRequest();

        _context.Entry(prontuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var prontuario = await _context.Prontuarios.FindAsync(id);

        if (prontuario == null)
            return NotFound();

        _context.Prontuarios.Remove(prontuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}