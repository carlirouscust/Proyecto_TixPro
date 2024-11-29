using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.Services;

public class CobrosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int _cobroId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Cobros
            .AnyAsync(T => T.cobrosId == _cobroId);
    }

    public async Task<bool> Insertar(Cobros _cobros)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Cobros.Add(_cobros);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cobros _cobros)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Cobros.Update(_cobros);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cobros _cobros)
    {
        if (!await Existe(_cobros.cobrosId))
            return await Insertar(_cobros);
        else
            return await Modificar(_cobros);
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _cobros = await _context.Cobros.
            Where(T => T.cobrosId == id).ExecuteDeleteAsync();
        return _cobros > 0;
    }

    public async Task<Cobros?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Cobros.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.cobrosId == id);
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Cobros
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }

    public async Task<List<Cobros>> ObtenerCobro()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Cobros.ToListAsync();
    }
}
