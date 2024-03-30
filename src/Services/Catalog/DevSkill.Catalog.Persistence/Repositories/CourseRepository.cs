using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Domain.Catalog.Entities;

namespace DevSkill.Catalog.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }
    }
}
