namespace DevSkill.Order.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Domain.Entities.Order>
    {
        Task<List<Domain.Entities.Order>> GetOrdersByUserIdAsync(string userId);

        Task<Domain.Entities.Order?> GetOrdersByUserCourse(Guid courseId, string userId);
    }
}
