using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Api_EfCore.Extensions
{
    public static class DataPaginationExtension
    {
        public static async Task<Pagination<TModel>> PaginationAsync<TModel>(this IQueryable<TModel> query, PaginationRequest config, CancellationToken cancellationToken)
            where TModel : IModel
        {

            var currentPage = config.Page;
            var currentLimit = config.Limit;

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                       .Skip((currentPage - 1) * currentLimit)
                       .Take(currentLimit)
                       .ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(totalItems / (double)currentLimit);

            var paginationParams = new PaginationParams(currentLimit, currentPage, totalItems, totalPages);

            return new Pagination<TModel>(paginationParams, items);
        }
    }
}
