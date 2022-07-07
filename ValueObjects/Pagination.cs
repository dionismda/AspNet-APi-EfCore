using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.ValueObjects
{
    public class Pagination<TObject> : IPagination<TObject> where TObject : IEntity
    {
        public PaginationParams PaginationParams { get; private set; }
        public IReadOnlyCollection<TObject> Items { get; private set; }

        public Pagination(PaginationParams paginationParams, IReadOnlyCollection<TObject> items)
        {
            PaginationParams = paginationParams;
            Items = items;
        }
    }
}
