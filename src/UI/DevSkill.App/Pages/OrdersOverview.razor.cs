using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Order;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DevSkill.App.Pages
{
    public partial class OrdersOverview
    {
        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<OrdersListVm> Orders { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Orders = await OrderDataService.GetAllUserOrdersAsync();
        }


        [Inject]
        public HttpClient HttpClient { get; set; }

    }
}
