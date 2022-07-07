using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.AspNetCore.WebUtilities;

namespace AspNet_Api_EfCore.Services
{
    public class UriServices : IUriServices
    {
        private readonly string BaseUrl;
        private readonly string Route;

        public UriServices(string baseUrl, string route)
        {
            BaseUrl = baseUrl;
            Route = route;
        }

        public Uri GetPageUri(PaginationRequest filter)
        {
            var _enpointUri = new Uri(string.Concat(BaseUrl, Route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "page", filter.Page.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "limit", filter.Limit.ToString());
            return new Uri(modifiedUri);
        }

        public Uri GetPageUri(int page, int limit)
        {
            var _enpointUri = new Uri(string.Concat(BaseUrl, Route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "page", page.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "limit", limit.ToString());
            return new Uri(modifiedUri);
        }
    }
}
