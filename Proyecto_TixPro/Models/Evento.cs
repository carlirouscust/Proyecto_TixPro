using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Evento
{
    [Key]
    public int eventoId { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? nombre { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public DateTime fecha { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? lugar { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public decimal precio { get; set; }
}
