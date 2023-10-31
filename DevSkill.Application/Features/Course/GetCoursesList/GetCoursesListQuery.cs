using MediatR;

namespace DevSkill.Application.Features.Course.GetCoursesList;
public class GetCoursesListQuery : IRequest<List<CourseListVm>>
{
}

