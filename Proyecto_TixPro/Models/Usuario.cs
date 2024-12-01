using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_TixPro.Models;


public class Usuario
{
    [Key]
    public int usuarioId { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string? nombre { get; set; }

    [Required(ErrorMessage = "El Whatsapp es obligatorio")]
    public string? whatsapp { get; set; }

    [Required(ErrorMessage = "El Asunto es obligatorio")]
    public string? asunto { get; set; }

    [Required(ErrorMessage = "El Comentario es obligatorio")]
    public string? comentario { get; set; }

    public Tarjeta? tarjeta { get; set; }
    [ForeignKey("tarjeta")]
    public int tarjetaId { get; set; }

    public  ICollection<Ticket> Ticket { get; set; } = new List<Ticket>();
}
