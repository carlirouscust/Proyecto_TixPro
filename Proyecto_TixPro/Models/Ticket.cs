using Proyecto_TixPro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Ticket
{
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

    // Nueva propiedad para almacenar los códigos como texto separado por comas
    public string? codigosTickets { get; set; }

    // Método para generar códigos y guardarlos como una cadena
    public void GenerarCodigos()
    {
        var random = new Random();
        var codigos = new List<int>();

        for (int i = 0; i < cantidad; i++)
        {
            codigos.Add(random.Next(1000, 10000));
        }

        // Almacenar los códigos como una cadena separada por comas
        codigosTickets = string.Join(" - ", codigos);
    }
}
