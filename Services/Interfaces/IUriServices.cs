using AspNet_Api_EfCore.ValueObjects;

namespace AspNet_Api_EfCore.Services.Interfaces
{
    public interface IUriServices
    {
        public Uri GetPageUri(PaginationRequest filter);
        public Uri GetPageUri(int page, int limit);
    }
}
