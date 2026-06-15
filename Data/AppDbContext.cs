using Microsoft.EntityFrameworkCore;
using SGHSS.API.Models;

namespace SGHSS.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Paciente> Pacientes { get; set; }

    public DbSet<ProfissionalSaude> ProfissionaisSaude { get; set; }

    public DbSet<Consulta> Consultas { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Prontuario> Prontuarios { get; set; }

    public DbSet<Internacao> Internacoes { get; set; }

    public DbSet<Exame> Exames { get; set; }

    public DbSet<LogAuditoria> LogsAuditoria { get; set; }
}