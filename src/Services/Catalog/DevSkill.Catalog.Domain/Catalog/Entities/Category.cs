using DevSkill.Catalog.Domain.Common;

namespace DevSkill.Catalog.Domain.Catalog.Entities;

public class Category : AuditableEntity
{

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}