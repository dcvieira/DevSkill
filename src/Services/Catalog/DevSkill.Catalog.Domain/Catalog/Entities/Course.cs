

using DevSkill.Catalog.Domain.Common;

namespace DevSkill.Catalog.Domain.Catalog.Entities;
public class Course : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;

}

