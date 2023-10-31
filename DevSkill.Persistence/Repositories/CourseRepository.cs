

using DevSkill.Application.Contracts.Persistence;
using DevSkill.Domain.Catalog.Entities;

namespace DevSkill.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DevSkillDbContext dbContext) : base(dbContext)
        {
        }
    }
}
