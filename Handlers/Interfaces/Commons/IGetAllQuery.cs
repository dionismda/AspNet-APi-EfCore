using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ViewModels;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IGetAllQuery<TModel> : IRequest<IResultViewModel<IPagination<TModel>>> where TModel : IModel
    {
        public int? page { get; set; }
        public int? limit { get; set; }
    }
}
