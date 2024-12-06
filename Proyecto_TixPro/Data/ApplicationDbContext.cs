using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<Cobros> Cobros { get; set; }
    public DbSet<Tarjeta> Tarjeta { get; set; }
    public DbSet<Contacto> Contacto { get; set; }
    public DbSet<Carrusel> Carrusel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.tarjeta)
            .WithOne(t => t.usuario)
            .HasForeignKey<Usuario>(u => u.tarjetaId);
    }

}
