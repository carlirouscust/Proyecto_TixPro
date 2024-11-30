using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.Data;

public class Contexto(DbContextOptions<Contexto> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<Cobros> Cobros { get; set; }
    public DbSet<Tarjeta> Tarjeta { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    //base.OnModelCreating(modelBuilder); // Configuración predeterminada de Identity

    //    // Aquí agregas tus configuraciones adicionales, como:
    //    modelBuilder.Entity<Evento>()
    //        .Property(e => e.precio)
    //        .HasColumnType("decimal(18,2)");

    //}



}
