using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize]
public class PacientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PacientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> Listar()
    {
        return await _context.Pacientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paciente>> BuscarPorId(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente == null)
            return NotFound();

        return paciente;
    }

    [HttpPost]
    public async Task<ActionResult<Paciente>> Criar(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Paciente paciente)
    {
        if (id != paciente.Id)
            return BadRequest();

        _context.Entry(paciente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente == null)
            return NotFound();

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}