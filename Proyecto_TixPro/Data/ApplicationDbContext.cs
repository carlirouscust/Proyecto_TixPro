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
}
