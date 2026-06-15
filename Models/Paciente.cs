using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Paciente
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string CPF { get; set; } = string.Empty;

    [Required]
    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}