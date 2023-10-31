using MediatR;

namespace DevSkill.Application.Features.Order.Queries.GetOrderByCourse
{
    public class GetOrderByCourseQuery : IRequest<OrderVm>
    {
        public Guid CourseId { get; set; }
    }
}
