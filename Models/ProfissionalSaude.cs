using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class ProfissionalSaude
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string CRM { get; set; } = string.Empty;

    [Required]
    public string Especialidade { get; set; } = string.Empty;

    [Required]
    public string Cargo { get; set; } = string.Empty;
}