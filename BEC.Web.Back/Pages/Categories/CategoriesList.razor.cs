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
using BEC.Web.Back.Shared;
using BEC.Core;
using BEC.UseCases.Utilities;

namespace BEC.Web.Back.Pages.Categories
{
    public partial class CategoriesList
    {
        public CategoriesList()
        {
            allCategories = new List<Category>();
            UseCasePagingParameters = new UseCasePagingParameters();
        }

        private List<Category>? allCategories;
        
        public UseCasePagingParameters? UseCasePagingParameters { get; set; }

        [Parameter]
        public int? PageNumber { get; set; }
        [Parameter]
        public int? PageSize { get; set; }
        public int? TotalPages { get; private set; }
        public int? TotalCount { get; private set; }
        //public int? CurrentPage { get; private set; }

        //  Lifecycle event of the component.  Triggered whenever the paramemter is changed, or when 
        // the component is first loaded and the parameter is set for the first time.
        protected override async Task OnInitializedAsync()
        {
            // If pageSize == null - set to 1 (passed in)
            UseCasePagingParameters.PageSize = (PageSize.HasValue) ? PageSize.Value : UseCasePagingParameters.PageSize;
            // If pageNumber == null - set to 1 (passed in)
            UseCasePagingParameters.PageNumber = (PageNumber.HasValue) ? PageNumber.Value : UseCasePagingParameters.PageNumber;
            //  we need Totalpages, TotalCount
            var pagedList = await ViewCategoriesUsecase.ExecuteAsync(UseCasePagingParameters);
            TotalPages = pagedList.TotalPages;
            TotalCount = pagedList.TotalCount;
            //CurrentPage = pagedList.TotalCount;
            allCategories = pagedList.ToList();
        }


        protected async Task NextPageAsync()
        {
            // so long as current page <= total pages
            if(UseCasePagingParameters.PageNumber < TotalPages)
            {
                UseCasePagingParameters.PageNumber++;
                allCategories = (await ViewCategoriesUsecase.ExecuteAsync(UseCasePagingParameters)).ToList();
            }

            
        }

        protected async Task PrevPageAsync()
        {
            if(UseCasePagingParameters.PageNumber > 1)
            {
                UseCasePagingParameters.PageNumber--;
                allCategories = (await ViewCategoriesUsecase.ExecuteAsync(UseCasePagingParameters)).ToList();
            }   
            
        }

        protected async Task ShowPagesAsync(int i)
        {
            UseCasePagingParameters.PageNumber = i;
            allCategories = (await ViewCategoriesUsecase.ExecuteAsync(UseCasePagingParameters)).ToList();
        }
    }
}