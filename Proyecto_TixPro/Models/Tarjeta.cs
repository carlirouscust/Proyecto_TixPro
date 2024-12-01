using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Proyecto_TixPro.Models;

public class Tarjeta
{
    [Key]
    public int tarjetaId { get; set; }

    [Required(ErrorMessage = "El Nombre del titular es Ogligatorio")]
    public string? nombreTitular { get; set; }

    [Required(ErrorMessage = "El Numero de tarjeta es Obligatorio")]
    public string? numeroTarjeta { get; set; }

    [Required(ErrorMessage = "La Fecha de expiracion es Obligatoria")]
    public string? fechaExpiracion { get; set; }

    [Required(ErrorMessage = "El Codigo de seguridad es Obligatorio")]
    public string? codigoSeguridad { get; set; }

    public Usuario? usuario { get; set; }

}
