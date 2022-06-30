using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.Extensions.Caching.Memory;

namespace AspNet_Api_EfCore.Handlers
{
    public class CategoryHandler :
        ICommandHandler<GetAllCategoryQuery, IEnumerable<Category>>,
        ICommandHandler<GetCategoryQuery, Category>,
        ICommandHandler<CreateCategoryCommand, Category>,
        ICommandHanlder<RequestId, UpdateCategoryCommand, Category>,
        ICommandHandler<DeleteCategoryCommand, bool>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;

        public CategoryHandler(ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request)
        {
            return await _memoryCache.GetOrCreateAsync<IEnumerable<Category>>("CategoriesCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return await _categoryRepository.GetAll();
            });

        }

        public async Task<Category> Handle(GetCategoryQuery request)
        {
            return await _categoryRepository.GetById(request.Id);
        }

        public async Task<Category> Handle(CreateCategoryCommand command)
        {
            Category category = new Category
            {
                Name = command.Name,
                Slug = command.Slug,
            };

            return await _categoryRepository.Add(category);
        }

        public async Task<Category> Handle(RequestId requestId, UpdateCategoryCommand command)
        {
            Category category = await _categoryRepository.GetById(requestId.Id);

            if (category == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            category.Name = command.Name;
            category.Slug = command.Slug;

            return await _categoryRepository.Update(category);
        }

        public async Task<bool> Handle(DeleteCategoryCommand command)
        {
            Category category = await _categoryRepository.GetById(command.Id);

            if (category == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return await _categoryRepository.Delete(category);
        }

    }
}
