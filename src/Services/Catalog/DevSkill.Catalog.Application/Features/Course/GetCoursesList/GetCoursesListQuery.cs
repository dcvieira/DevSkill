using MediatR;

namespace DevSkill.Catalog.Application.Features.Course.GetCoursesList;
public class GetCoursesListQuery : IRequest<List<CourseListVm>>
{
}

