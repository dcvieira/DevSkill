using DevSkill.Domain.Order.Enums;

namespace DevSkill.Application.Features.Order.Queries.GetOrderByCourse
{
    public class OrderVm
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string UserId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
