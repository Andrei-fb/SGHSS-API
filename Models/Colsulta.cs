using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Consulta
{
    public int Id { get; set; }

    [Required]
    public DateTime DataConsulta { get; set; }

    [Required]
    public string Tipo { get; set; } = string.Empty; // Presencial ou Telemedicina

    [Required]
    public string Status { get; set; } = string.Empty;

    public int PacienteId { get; set; }

    public int ProfissionalSaudeId { get; set; }

    public Paciente? Paciente { get; set; }

    public ProfissionalSaude? ProfissionalSaude { get; set; }
}