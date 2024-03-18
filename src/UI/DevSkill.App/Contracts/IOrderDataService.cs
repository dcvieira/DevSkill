using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts
{
    public interface IOrderDataService
    {
        Task<List<OrdersListVm>> GetAllUserOrdersAsync();

        Task<ApiResponse<Guid>> CreateOrder(CreateOrderViewModel createOrderViewModel);

        Task<OrderVm?> GetCourseOrderAsync(Guid courseId);
    }
}
