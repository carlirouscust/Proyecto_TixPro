using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;


public class Usuario
{
    [Key]
    public int usuarioId { get; set; }
    public string? nombre { get; set; }
    public string? email { get; set; }
    public string? contraseña { get; set; }
}
