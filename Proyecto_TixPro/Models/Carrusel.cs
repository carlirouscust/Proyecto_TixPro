using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Carrusel
{
    [Key]
    public int carruselId { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? imagen1 { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? imagen2 { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? imagen3 { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? imagen4 { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? imagen5 { get; set; }
}
