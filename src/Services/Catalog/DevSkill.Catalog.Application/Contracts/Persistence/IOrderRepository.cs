using DevSkill.Catalog.Domain.Order.Entities;


namespace DevSkill.Catalog.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        Task<Order?> GetOrdersByUserCourse(Guid courseId, string userId);
    }
}
