using System.Linq.Expressions;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.DAL;
using Proyecto_TixPro.Models;
namespace Proyecto_TixPro.Services;

public class UsuariosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int _usuarioId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Usuario
            .AnyAsync(T => T.usuarioId == _usuarioId);
    }

    public async Task<bool> Insertar(Usuario _usuario)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Usuario.Add(_usuario);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Usuario _usuario)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Usuario.Update(_usuario);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Usuario _usuario)
    {
        if (!await Existe(_usuario.usuarioId))
            return await Insertar(_usuario);
        else
            return await Modificar(_usuario);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _usuario = await _context.Usuario.
            Where(T => T.usuarioId == id).ExecuteDeleteAsync();
        return _usuario > 0;
    }

    public async Task<Usuario?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Usuario.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.usuarioId == id);
    }

    public async Task<List<Usuario>> Listar(Expression<Func<Usuario, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Usuario.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }

}
