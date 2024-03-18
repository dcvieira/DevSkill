using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DevSkill.App.Pages
{
    public partial class Catalog
    {
        [Inject]
        public ICourseDataService CourseDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }



        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Courses = await CourseDataService.GetAllCourses();
          
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

    }
}
