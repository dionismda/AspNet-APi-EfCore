using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using AspNet_Api_EfCore.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace AspNet_Api_EfCore.Handlers
{
    public class CategoryHandler : BaseHandler<Category>, ICategoryHandler
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;

        public CategoryHandler(ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _memoryCache = memoryCache;
        }

        //public async override Task<IEnumerable<Category>> Handle(IGetAllQuery<Category> request, CancellationToken cancellationToken)
        //{
        //    return await _memoryCache.GetOrCreateAsync<IEnumerable<Category>>("CategoriesCache", async entry =>
        //    {
        //        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
        //        return await _categoryRepository.GetAll();
        //    });
        //}

        public async override Task<IResultViewModel<IPagination<Category>>> Handle(IGetAllQuery<Category> request, CancellationToken cancellationToken)
        {
            GetAllCategoryQuery command = (GetAllCategoryQuery)request;

            var config = new PaginationRequest(command?.page, command?.limit);

            var categories = await _categoryRepository.GetPaginationAsync(config, cancellationToken);

            return new ResultViewModel<IPagination<Category>>("getall", "getall", categories);
        }

        public async override Task<IResultViewModel<Category>> Handle(IGetByIdQuery<Category> request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);

            return new ResultViewModel<Category>("getbyid", "getbyid", category);
        }


        public async override Task<IResultViewModel<Category>> Handle(IInsertCommand<Category> request, CancellationToken cancellationToken)
        {
            CreateCategoryCommand command = (CreateCategoryCommand)request;

            Category category = new Category
            {
                Name = command.Name,
                Slug = command.Slug,
            };

            var newCategory = await _categoryRepository.Add(category);

            return new ResultViewModel<Category>("getbyid", "getbyid", newCategory);
        }

        public async override Task<IResultViewModel<Category>> Handle(IUpdateCommand<Category> request, CancellationToken cancellationToken)
        {
            UpdateCategoryCommand command = (UpdateCategoryCommand)request;

            Category category = await _categoryRepository.GetById(command.Id);

            if (category == null)
            {
                return new ResultViewModel<Category>("warning", "category not found", command);
            }

            category.Name = command.Name;
            category.Slug = command.Slug;

            var newCategory = await _categoryRepository.Update(category);

            return new ResultViewModel<Category>("getbyid", "getbyid", newCategory);
        }

        public async override Task<bool> Handle(IDeleteCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetById(request.Id);

            if (category == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return await _categoryRepository.Delete(category);
        }

    }
}
