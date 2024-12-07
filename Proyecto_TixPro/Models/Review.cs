using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Review
{
    [Key]
    public int reviewId { get; set; }
    [Required(ErrorMessage = "El Campo es obligatorio")]
    public string? usuarioNombre { get; set; } 

    [Required(ErrorMessage = "El Campo es obligatorio")]
    public int ratingUso { get; set; } // Puntuación (1 a 10)

    [Required(ErrorMessage = "El Campo es obligatorio")]
    public string? cosasMejorar { get; set; } 

    [Required(ErrorMessage = "El Campo es obligatorio")]
    public bool recomendarias { get; set; } 
    public DateTime fechaReview { get; set; } = DateTime.Now; 
}
