namespace AspNet_Api_EfCore.ValueObjects
{
    public class PaginationParams
    {
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public PaginationParams(int pageSize, int currentPage, int totalItems, int totalPages)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}
