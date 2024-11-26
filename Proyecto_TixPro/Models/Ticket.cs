using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; } 
    public int EventoId { get; set; } 
    public double Precio { get; set; } 
    public DateTime FechaCompra { get; set; } 
    public int UsuarioId { get; set; } 

}
