using BEC.Core;

namespace BEC.UseCases.Interfaces
{
    public interface IAddCategoryUseCase
    {
        Task ExecuteAsync(Category category);
    }
}