﻿using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Events { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
}
