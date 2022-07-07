using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Services;
using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Api_EfCore.Extensions
{
    public static class DataPaginationExtension
    {
        public static async Task<Pagination<TModel>> PaginationAsync<TModel>(this IQueryable<TModel> query, PaginationRequest config, IUriServices uriServices, CancellationToken cancellationToken)
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

            var links = new List<Uri>();
            
            for(var i = 1; i <= totalPages; i++)
            {
                links.Add(uriServices.GetPageUri(i, currentLimit));
            }            

            return new Pagination<TModel>(paginationParams, items, links);
        }
    }
}
