using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_TixPro.Models;

public class Ticket
{
    [Key]
    public int ticketId { get; set; }

    public Evento? evento { get; set; }
    [ForeignKey("evento")]
    public int eventoId { get; set; } 
    public double precio { get; set; } 
    public DateTime fechaCompra { get; set; } 

    public Usuario? usuario { get; set; }
    [ForeignKey("usuario")]
    public int usuarioId { get; set; } 
    
}
