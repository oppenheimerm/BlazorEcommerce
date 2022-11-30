using BEC.Core;
using BEC.UseCases.DataStoreInterfaces;
using BEC.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEC.UseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
	{
		private readonly ICategoryRepository categoryRepository;

		public AddCategoryUseCase(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		public async Task ExecuteAsync(Category category)
		{
			await categoryRepository.AddCategoryAsync(category);
		}
	}
}
