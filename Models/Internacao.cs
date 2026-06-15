using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Internacao
{
    public int Id { get; set; }

    [Required]
    public DateTime DataEntrada { get; set; }

    public DateTime? DataAlta { get; set; }

    [Required]
    public string Leito { get; set; } = string.Empty;

    public int PacienteId { get; set; }

    public Paciente? Paciente { get; set; }
}