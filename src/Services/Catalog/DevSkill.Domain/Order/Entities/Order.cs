using DevSkill.Domain.Common;
using DevSkill.Domain.Order.Enums;

namespace DevSkill.Domain.Order.Entities;
public class Order : AuditableEntity
{
    public Guid Id { get; set; }

    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }

    public Guid CourseId { get; set; }
    public string CourseName { get; set; }

    public OrderStatus OrderStatus { get; set; }
    public int Price { get; set; }

    public OrderDetails OrderDetails { get; set; }

}

