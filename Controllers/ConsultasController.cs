using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize]
public class ConsultasController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConsultasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consulta>>> Listar()
    {
        return await _context.Consultas
            .Include(c => c.Paciente)
            .Include(c => c.ProfissionalSaude)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consulta>> BuscarPorId(int id)
    {
        var consulta = await _context.Consultas
            .Include(c => c.Paciente)
            .Include(c => c.ProfissionalSaude)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (consulta == null)
            return NotFound();

        return consulta;
    }

    [HttpPost]
    public async Task<ActionResult<Consulta>> Criar(Consulta consulta)
    {
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = consulta.Id }, consulta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Consulta consulta)
    {
        if (id != consulta.Id)
            return BadRequest();

        _context.Entry(consulta).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);

        if (consulta == null)
            return NotFound();

        _context.Consultas.Remove(consulta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}