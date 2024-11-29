using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_TixPro.Models;

public class Ticket
{
    private static readonly Random random = new Random();

    [Key]
    public int ticketId { get; set; }

    public Evento? evento { get; set; }
    [ForeignKey("evento")]
    public int eventoId { get; set; }

    public decimal monto { get; set; }
    public int cantidad { get; set; }

    public int? codigoTicket { get; set; } = random.Next(1000, 10000);

    
}
