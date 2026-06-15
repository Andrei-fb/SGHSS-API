using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Exame
{
    public int Id { get; set; }

    [Required]
    public string NomeExame { get; set; } = string.Empty;

    [Required]
    public DateTime DataExame { get; set; }

    public string Resultado { get; set; } = string.Empty;

    public int PacienteId { get; set; }

    public Paciente? Paciente { get; set; }
}