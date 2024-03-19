
using DevSkill.Order.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Order.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order.Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order.Domain.Entities.Order?> GetOrdersByUserCourse(Guid courseId, string userId)
        {
            var order = await _dbContext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.CourseId == courseId && o.UserId == userId);
            return order;
        }

        public async Task<List<Order.Domain.Entities.Order>> GetOrdersByUserIdAsync(string userId)
        {
              return await _dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}


