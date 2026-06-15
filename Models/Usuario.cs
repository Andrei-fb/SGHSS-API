using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string SenhaHash { get; set; } = string.Empty;

    [Required]
    public string Perfil { get; set; } = string.Empty; // Administrador ou Profissional
}