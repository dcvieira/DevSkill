using DevSkill.Domain.Catalog.Entities;

namespace DevSkill.Application.Contracts.Persistence;

public interface ICourseRepository : IAsyncRepository<Course>
{
}

