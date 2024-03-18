
using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Domain.Catalog.Entities;

namespace DevSkill.Catalog.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }

    }
}
