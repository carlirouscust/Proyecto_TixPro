using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;
using System.Linq.Expressions;

namespace Proyecto_TixPro.Services;

public class ContactoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int _contactoId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Contacto
            .AnyAsync(T => T.contactoId == _contactoId);
    }

    public async Task<bool> Insertar(Contacto _contacto)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Contacto.Add(_contacto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Contacto _contacto)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Contacto.Update(_contacto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Contacto _contacto)
    {
        if (!await Existe(_contacto.contactoId))
            return await Insertar(_contacto);
        else
            return await Modificar(_contacto);
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _contacto = await _context.Contacto.
            Where(T => T.contactoId == id).ExecuteDeleteAsync();
        return _contacto > 0;
    }

    public async Task<Contacto?> Buscar(int id)
    {
        await using var _contacto = await DbFactory.CreateDbContextAsync();
        return await _contacto.Contacto.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.contactoId == id);
    }

    public async Task<List<Contacto>> Listar(Expression<Func<Contacto, bool>> criterio)
    {
        await using var _contacto = await DbFactory.CreateDbContextAsync();
        return _contacto.Contacto
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }

    public async Task<List<Contacto>> ObtenerCobro()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Contacto.ToListAsync();
    }
}
