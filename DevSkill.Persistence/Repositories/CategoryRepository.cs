using DevSkill.Application.Contracts.Persistence;
using DevSkill.Domain.Catalog.Entities;

namespace DevSkill.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }

    }
}
