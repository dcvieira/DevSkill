using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Domain.Catalog.Entities;
using DevSkill.Catalog.Domain.Order.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Catalog.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order?> GetOrdersByUserCourse(Guid courseId, string userId)
        {
            var order = await _dbContext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.CourseId == courseId && o.UserId == userId);
            return order;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
              return await _dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}


