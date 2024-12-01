using System;
using System.Collections.Generic;
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

    public Usuario? usuario { get; set; }

    [ForeignKey("usuario")]
    public int usuarioId { get; set; }

    public decimal monto { get; set; }

    public int cantidad { get; set; }

    [NotMapped] // Indica que esta propiedad no será mapeada en la base de datos
    public List<int> codigosTickets { get; set; } = new List<int>();

    // Constructor o método para generar los códigos
    public void GenerarCodigos()
    {
        codigosTickets.Clear(); // Asegúrate de limpiar la lista antes de generar nuevos códigos
        for (int i = 0; i < cantidad; i++)
        {
            codigosTickets.Add(random.Next(1000, 10000)); // Genera códigos aleatorios
        }
    }
}

