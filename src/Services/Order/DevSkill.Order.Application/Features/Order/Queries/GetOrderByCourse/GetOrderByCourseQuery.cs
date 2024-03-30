using MediatR;

namespace DevSkill.Order.Application.Features.Order.Queries.GetOrderByCourse
{
    public class GetOrderByCourseQuery : IRequest<OrderVm>
    {
        public Guid CourseId { get; set; }
    }
}
