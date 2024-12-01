using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Contacto
{
    [Key]
    public int contactoId { get; set; }

    [Required(ErrorMessage = "El Asunto es obligatorio")]
    public string? asunto { get; set; }

    [Required(ErrorMessage = "El Comentario es obligatorio")]
    public string? comentario { get; set; }

    [Required(ErrorMessage = "El Comentario es obligatorio")]
    public string? nombre { get; set; }

    [Required(ErrorMessage = "El Comentario es obligatorio")]
    public string? whatsapp {  get; set; }
}
