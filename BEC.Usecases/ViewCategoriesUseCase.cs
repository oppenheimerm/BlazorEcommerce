using BEC.Core;
using BEC.UseCases.DataStoreInterfaces;
using BEC.UseCases.Interfaces;
using BEC.UseCases.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEC.UseCases
{
    public class ViewCategoriesUsecase : IViewCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoriesUsecase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<PagedList<Category>> ExecuteAsync(UseCasePagingParameters useCasePagingParameters)
        {
            var Items = await categoryRepository.GetAllGategoriesAsync(useCasePagingParameters);
            return Items;
        }


    }
}
