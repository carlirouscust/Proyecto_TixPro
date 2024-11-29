using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_TixPro.Models;

public class Cobros
{
    [Key]
    public int cobrosId { get; set; }

    public decimal totalPagado { get; set; }

    public Usuario? usuario { get; set; }
    [ForeignKey("usuario")]
    public int usuarioId { get; set; }

    public Evento? evento { get; set; }
    [ForeignKey("evento")]
    public int eventoId { get; set; }
}
