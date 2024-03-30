using DevSkill.App.Contracts;
using DevSkill.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevSkill.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategories();
        }


    }
}
