﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_TixPro.Models;


public class Usuario
{
    [Key]
    public int usuarioId { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? nombre { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser Obligatorio")]
    public string? whatsapp { get; set; }

    public  ICollection<Ticket> Ticket { get; set; } = new List<Ticket>();
}
