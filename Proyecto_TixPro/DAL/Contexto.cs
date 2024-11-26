using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
}
