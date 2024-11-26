using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.Data;

public class Contexto(DbContextOptions<Contexto> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
}
