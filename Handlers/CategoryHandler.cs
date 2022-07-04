using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
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

        public async override Task<IEnumerable<Category>> Handle(IGetAllQuery<Category> request)
        {
            return await _memoryCache.GetOrCreateAsync<IEnumerable<Category>>("CategoriesCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return await _categoryRepository.GetAll();
            });
        }

        public async override Task<Category> Handle(IGetByIdQuery<Category> request)
        {
            return await _categoryRepository.GetById(request.Id);
        }

        public async override Task<Category> Handle(IInsertCommand<Category> request)
        {
            CreateCategoryCommand command = (CreateCategoryCommand)request;

            Category category = new Category
            {
                Name = command.Name,
                Slug = command.Slug,
            };

            return await _categoryRepository.Add(category);
        }

        public async override Task<Category> Handle(IRequestId id, IUpdateCommand<Category> request)
        {
            UpdateCategoryCommand command = (UpdateCategoryCommand)request;

            Category category = await _categoryRepository.GetById(id.Id);

            if (category == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            category.Name = command.Name;
            category.Slug = command.Slug;

            return await _categoryRepository.Update(category);
        }

        public async override Task<bool> Handle(IDeleteCommand request)
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
