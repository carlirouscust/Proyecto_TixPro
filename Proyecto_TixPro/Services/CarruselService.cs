using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;
using System.Linq.Expressions;

namespace Proyecto_TixPro.Services;

public class CarruselService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int _carruselId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Carrusel
            .AnyAsync(T => T.carruselId == _carruselId);
    }

    public async Task<bool> Insertar(Carrusel _carrusel)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Carrusel.Add(_carrusel);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Carrusel _carrusel)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Carrusel.Update(_carrusel);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Carrusel _carrusel)
    {
        if (!await Existe(_carrusel.carruselId))
            return await Insertar(_carrusel);
        else
            return await Modificar(_carrusel);
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _contacto = await _context.Carrusel.
            Where(T => T.carruselId == id).ExecuteDeleteAsync();
        return _contacto > 0;
    }

    public async Task<Carrusel?> Buscar(int id)
    {
        await using var _carrusel = await DbFactory.CreateDbContextAsync();
        return await _carrusel.Carrusel.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.carruselId == id);
    }

    public async Task<List<Carrusel>> Listar(Expression<Func<Carrusel, bool>> criterio)
    {
        await using var _carrusel = await DbFactory.CreateDbContextAsync();
        return _carrusel.Carrusel
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }

    public async Task<Carrusel?> ObtenerUltimoCarruselAsync()
    {
        await using var _carrusel = await DbFactory.CreateDbContextAsync();
        try
        {
            return await _carrusel.Carrusel
                .OrderByDescending(c => c.carruselId)
                .FirstOrDefaultAsync();
        }
        catch
        {
            return null;
        }

    }

}
