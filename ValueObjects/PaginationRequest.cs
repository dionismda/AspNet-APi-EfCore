namespace AspNet_Api_EfCore.ValueObjects
{
    public class PaginationRequest
    {
        public int Page { get; private set; }
        public int Limit { get; private set; }
        public PaginationRequest(int? page, int? limit)
        {
            Page = (page == null || page <= 0) ? 1 : (int)page;
            Limit = (limit == null) ? 50 : (int)limit;
        }
    }
}
