using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Proyecto_TixPro.Models;

public class Tarjeta
{
    [Key]
    public int tarjetaId { get; set; }
    public string? nombreTitular { get; set; }
    public string? numeroTarjeta { get; set; }
    public string fechaExpiracion { get; set; }
    public string? codigoSeguridad { get; set; }
}
