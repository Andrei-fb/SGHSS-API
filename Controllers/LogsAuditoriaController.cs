using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.API.Data;
using SGHSS.API.Models;

namespace SGHSS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class LogsAuditoriaController : ControllerBase
{
    private readonly AppDbContext _context;

    public LogsAuditoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogAuditoria>>> Listar()
    {
        return await _context.LogsAuditoria.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<LogAuditoria>> Criar(LogAuditoria log)
    {
        _context.LogsAuditoria.Add(log);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Listar), new { id = log.Id }, log);
    }
}