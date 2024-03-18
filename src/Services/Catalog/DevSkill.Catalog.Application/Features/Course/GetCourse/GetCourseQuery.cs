using MediatR;

namespace DevSkill.Catalog.Application.Features.Course.GetCourse;
public class GetCourseQuery : IRequest<CourseVm>
{
    public Guid CourseId { get; set; }
}
