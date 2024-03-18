using DevSkill.Domain.Common;

namespace DevSkill.Domain.Catalog.Entities;

public class Category : AuditableEntity
{

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}