using BEC.Core;
using BEC.UseCases.Utilities;

namespace BEC.UseCases.Interfaces
{
    public interface IViewCategoriesUseCase
    {
        Task<PagedList<Category>> ExecuteAsync(UseCasePagingParameters useCasePagingParameters);
    }
}