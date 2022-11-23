using BEC.Core;
using BEC.UseCases.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEC.UseCases.DataStoreInterfaces
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllGategoriesAsync(UseCasePagingParameters useCasePagingParameters);
        Task AddCategoryAsync(Category category);
    }
}
