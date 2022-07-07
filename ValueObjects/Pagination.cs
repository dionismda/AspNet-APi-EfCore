using AspNet_Api_EfCore.Interfaces;
using System.Text.Json.Serialization;

namespace AspNet_Api_EfCore.ValueObjects
{
    public class Pagination<TObject> : IPagination<TObject> where TObject : IEntity
    {
        [JsonPropertyName("pagination")]
        public PaginationParams PaginationParams { get; private set; }
        public IReadOnlyCollection<TObject> Items { get; private set; }
        public IList<Uri> Links { get; private set; }
        public Pagination(PaginationParams paginationParams, IReadOnlyCollection<TObject> items, IList<Uri> links)
        {
            PaginationParams = paginationParams;
            Items = items;
            Links = links;
        }
    }
}
