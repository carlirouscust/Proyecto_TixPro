using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;

public class Evento
{
    [Key]
    public int eventoId { get; set; }
    public string? nombre { get; set; }
    public DateTime fecha { get; set; }
    public string? lugar { get; set; }
    public decimal precio { get; set; }
}
