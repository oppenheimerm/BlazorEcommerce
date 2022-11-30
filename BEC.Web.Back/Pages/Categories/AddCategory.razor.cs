using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using BEC.Web.Back;
using BEC.Web.Back.Shared;
using BEC.Core;
using BEC.UseCases;
using BEC.UseCases.Interfaces;

namespace BEC.Web.Back.Pages.Categories
{
    public partial class AddCategory
    {
        [Inject]
        private IAddCategoryUseCase addCategoryUseCase { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private Category Category { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            Category = new Category();
        }

        private async Task OnValidSubmit()
        {
            await addCategoryUseCase.ExecuteAsync(Category);
            NavigationManager.NavigateTo("/categories");
        }

        private void OnClickBackToList()
        {
			NavigationManager.NavigateTo("/categories");
		}

	}
}