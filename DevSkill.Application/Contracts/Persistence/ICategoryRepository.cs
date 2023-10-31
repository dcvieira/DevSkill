using DevSkill.Domain.Catalog.Entities;

namespace DevSkill.Application.Contracts.Persistence;
public interface ICategoryRepository : IAsyncRepository<Category>
{
}

