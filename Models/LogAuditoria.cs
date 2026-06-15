using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class LogAuditoria
{
    public int Id { get; set; }

    [Required]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    public string Acao { get; set; } = string.Empty;

    [Required]
    public string Entidade { get; set; } = string.Empty;

    public DateTime DataHora { get; set; } = DateTime.Now;
}