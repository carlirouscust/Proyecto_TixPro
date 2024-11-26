using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;


public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
}
