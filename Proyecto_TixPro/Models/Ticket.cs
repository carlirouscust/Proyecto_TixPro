using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Ticket
{
        [Key]
        public int ticketId { get; set; } 
        public int eventoId { get; set; } 
        public double precio { get; set; } 
        public DateTime fechaCompra { get; set; } 
        public int usuarioId { get; set; } 
    
}
