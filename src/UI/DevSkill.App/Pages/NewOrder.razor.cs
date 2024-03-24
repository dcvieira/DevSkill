using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Catalog;
using DevSkill.App.Services.Base.Order;
using DevSkill.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DevSkill.App.Pages
{
    public partial class NewOrder
    {
        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        [Inject]
        public ICourseDataService CourseDataService { get; set; }

        [Inject]
        public ICheckoutDataService CheckoutDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CheckoutViewModel CheckoutViewModel { get; set; }
        public OrderVm? CourseOrder { get; set; }

        public CourseVm? Course { get; set; }
        public string Message { get; set; }
        public bool Submitted { get; set; }

        [Parameter]
        public string CourseId { get; set; }
   

        protected async override Task OnInitializedAsync()
        {
            CheckoutViewModel = new CheckoutViewModel();
            CheckoutViewModel.CourseId = Guid.Parse(CourseId);
            Course = await CourseDataService.GetCourse(CheckoutViewModel.CourseId);

            CourseOrder = await OrderDataService.GetCourseOrderAsync(CheckoutViewModel.CourseId);
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CheckoutDataService.Checkout(CheckoutViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Order submited";
                Submitted = true;
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
