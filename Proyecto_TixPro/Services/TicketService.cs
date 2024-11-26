using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;
using System.Linq.Expressions;

namespace Proyecto_TixPro.Services;

public class TicketService(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Existe(int _ticketId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Ticket
            .AnyAsync(T => T.ticketId == _ticketId);
    }

    public async Task<bool> Insertar(Ticket _ticket)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Ticket.Add(_ticket);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Ticket _ticket)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Ticket.Update(_ticket);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Ticket _ticket)
    {
        if (!await Existe(_ticket.ticketId))
            return await Insertar(_ticket);
        else
            return await Modificar(_ticket);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _ticket = await _context.Ticket.
            Where(T => T.ticketId == id).ExecuteDeleteAsync();
        return _ticket > 0;
    }

    public async Task<Ticket?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Ticket.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.ticketId == id);
    }

    public async Task<List<Ticket>> Listar(Expression<Func<Ticket, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Ticket.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
