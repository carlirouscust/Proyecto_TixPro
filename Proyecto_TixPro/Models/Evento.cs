using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Evento
{
    [Key]
    public int eventoId { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public DateTime fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string lugar { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal precio { get; set; }

    public string? imagen { get; set; }
}

