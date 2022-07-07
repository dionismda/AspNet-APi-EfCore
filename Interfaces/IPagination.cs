namespace AspNet_Api_EfCore.Interfaces
{
    public interface IPagination<TObject> : IEntity where TObject : IEntity
    {
    }
}
