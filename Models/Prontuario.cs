using System.ComponentModel.DataAnnotations;

namespace SGHSS.API.Models;

public class Prontuario
{
    public int Id { get; set; }

    [Required]
    public string Diagnostico { get; set; } = string.Empty;

    public string Observacoes { get; set; } = string.Empty;

    public string Prescricao { get; set; } = string.Empty;

    public int ConsultaId { get; set; }

    public Consulta? Consulta { get; set; }
}