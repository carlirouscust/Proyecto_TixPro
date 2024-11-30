using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;
using System.Linq.Expressions;

namespace Proyecto_TixPro.Services;

public class TarjetaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int _tarjetaId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tarjeta
            .AnyAsync(T => T.tarjetaId == _tarjetaId);
    }

    public async Task<bool> Insertar(Tarjeta _tarjeta)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Tarjeta.Add(_tarjeta);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tarjeta _tarjeta)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Tarjeta.Update(_tarjeta);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tarjeta _tarjeta)
    {
        if (!await Existe(_tarjeta.tarjetaId))
            return await Insertar(_tarjeta);
        else
            return await Modificar(_tarjeta);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _tarjeta = await _context.Tarjeta.
            Where(T => T.tarjetaId == id).ExecuteDeleteAsync();
        return _tarjeta > 0;
    }

    public async Task<Tarjeta?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tarjeta.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.tarjetaId == id);
    }

    public async Task<List<Tarjeta>> Listar(Expression<Func<Tarjeta, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Tarjeta.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
