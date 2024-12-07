using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Proyecto_TixPro.Data;
using Proyecto_TixPro.Models;

namespace Proyecto_TixPro.Services;

public class ReviewService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int _reviewId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Review
            .AnyAsync(T => T.reviewId == _reviewId);
    }

    public async Task<bool> Insertar(Review _review)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Review.Add(_review);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Review _review)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Review.Update(_review);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Review _review)
    {
        if (!await Existe(_review.reviewId))
            return await Insertar(_review);
        else
            return await Modificar(_review);
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var _review = await _context.Review.
            Where(T => T.reviewId == id).ExecuteDeleteAsync();
        return _review > 0;
    }

    public async Task<Review?> Buscar(int id)
    {
        await using var _review = await DbFactory.CreateDbContextAsync();
        return await _review.Review.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.reviewId == id);
    }

    public async Task<List<Review>> Listar(Expression<Func<Review, bool>> criterio)
    {
        await using var _review = await DbFactory.CreateDbContextAsync();
        return _review.Review
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
