using MediatR;

namespace DevSkill.Application.Features.Course.GetCourse;
public class GetCourseQuery : IRequest<CourseVm>
{
    public Guid CourseId { get; set; }
}
