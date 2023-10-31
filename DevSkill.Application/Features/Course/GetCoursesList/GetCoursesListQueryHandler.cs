using AutoMapper;
using DevSkill.Application.Contracts.Persistence;
using MediatR;

namespace DevSkill.Application.Features.Course.GetCoursesList;
public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseListVm>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCoursesListQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<List<CourseListVm>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
       var courses = await _courseRepository.ListAllAsync();
        return _mapper.Map<List<CourseListVm>>(courses);
    }
}
