using BEC.Core;
using BEC.UseCases.DataStoreInterfaces;
using BEC.UseCases.Utilities;

namespace BEC.DataStore.InMemory
{
    public class CategoryRepository : ICategoryRepository

    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            //  Category Id's 
            //  1 = cook, 2 = clean, 3 = bake, drink = 4, pots and pans = 5, utensils = 6
            _categories = new List<Category>()
            {
                new Category { Id = 1,  CategoryCode = "FDPY", Title = "Food - Poultry"},
                new Category { Id = 2,  CategoryCode = "FDBF", Title = "Food - Beef"},
                new Category { Id = 3,  CategoryCode = "FDCK", Title = "Food - Chicken"},
                new Category { Id = 4,  CategoryCode = "FDLM", Title = "Food - Lamb"},
                new Category { Id = 5,  CategoryCode = "FDOT", Title = "Food - Meat Other"},
                new Category { Id = 6,  CategoryCode = "BVSD", Title = "Baverage - Softdrinks"},
                new Category { Id = 7,  CategoryCode = "ALWN", Title = "Alcohol - Wine"},
                new Category { Id = 8,  CategoryCode = "ALSP", Title = "Alcohol - Spirts"},
                new Category { Id = 9,  CategoryCode = "BVWT", Title = "Beverage - Water"},
                new Category { Id = 10,  CategoryCode = "BKBD", Title = "Bakery - Bread"},
                new Category { Id = 11,  CategoryCode = "BKCK", Title = "Bakery - Cakes & Pastries"},
                new Category { Id = 12,  CategoryCode = "HHDT", Title = "Health & Beauty - Dental"},
                new Category { Id = 13,  CategoryCode = "HHPX", Title = "Health & Beauty - Pharmacy"},
                new Category { Id = 14,  CategoryCode = "FDRM", Title = "Food - Ready made meals"}
            };
        }

        public Task AddCategoryAsync(Category category)
        {
            //  Prevent duplicate
            if (_categories.Any(x => x.CategoryCode.Equals(category.CategoryCode, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _categories.Max(x => x.Id);
            category.Id = maxId + 1;

            _categories.Add(category);

            return Task.CompletedTask;
        }

        public async Task<PagedList<Category>> GetAllGategoriesAsync(UseCasePagingParameters useCasePagingParameters)
        {
            //  Use .AsQuerable() as opposed to ToList() - which will just creates the query.
            var categories = PagedList<Category>.ToPagedList(_categories.AsQueryable().OrderBy(x => x.Title),
                useCasePagingParameters.PageNumber,
                useCasePagingParameters.PageSize);


            return (PagedList<Category>)await Task.FromResult(categories);

        }

    }
}