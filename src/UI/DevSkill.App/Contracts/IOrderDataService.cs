using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Order;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts
{
    public interface IOrderDataService
    {
        Task<List<OrdersListVm>> GetAllUserOrdersAsync();

        Task<OrderVm?> GetCourseOrderAsync(Guid courseId);
    }
}
