using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize(Roles = "Administrador")]
public class ProfissionaisController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProfissionaisController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfissionalSaude>>> Listar()
    {
        return await _context.ProfissionaisSaude.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfissionalSaude>> BuscarPorId(int id)
    {
        var profissional = await _context.ProfissionaisSaude.FindAsync(id);

        if (profissional == null)
            return NotFound();

        return profissional;
    }

    [HttpPost]
    public async Task<ActionResult<ProfissionalSaude>> Criar(ProfissionalSaude profissional)
    {
        _context.ProfissionaisSaude.Add(profissional);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = profissional.Id }, profissional);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, ProfissionalSaude profissional)
    {
        if (id != profissional.Id)
            return BadRequest();

        _context.Entry(profissional).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var profissional = await _context.ProfissionaisSaude.FindAsync(id);

        if (profissional == null)
            return NotFound();

        _context.ProfissionaisSaude.Remove(profissional);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}