using DevSkill.Domain.Order.Entities;


namespace DevSkill.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        Task<Order?> GetOrdersByUserCourse(Guid courseId, string userId);
    }
}
