namespace AspNet_Api_EfCore.Models
{
    public class Tag : Model
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
