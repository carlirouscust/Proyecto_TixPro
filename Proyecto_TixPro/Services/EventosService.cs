﻿using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;
using System.Linq.Expressions;

namespace Proyecto_TixPro.Services;

public class EventosService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int _eventoId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Evento
            .AnyAsync(T => T.eventoId == _eventoId);
    }

    public async Task<bool> Insertar(Evento _evento)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Evento.Add(_evento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Evento _evento)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Evento.Update(_evento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Evento _evento)
    {
        if (string.IsNullOrEmpty(_evento.lugar))
        {
            throw new ArgumentException("El campo lugar es obligatorio.");
        }

        if (!await Existe(_evento.eventoId))
            return await Insertar(_evento);
        else
            return await Modificar(_evento);
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _evento = await _context.Evento.
            Where(T => T.eventoId == id).ExecuteDeleteAsync();
        return _evento > 0;
    }

    public async Task<Evento?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Evento.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.eventoId == id);
    }

    public async Task<List<Evento>> Listar(Expression<Func<Evento, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Evento
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }

    public async Task<List<Evento>> ObtenerEvento()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Evento.ToListAsync();
    }
}
