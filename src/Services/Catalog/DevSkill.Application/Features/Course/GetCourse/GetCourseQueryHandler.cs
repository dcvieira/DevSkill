using AutoMapper;
using DevSkill.Application.Contracts.Persistence;
using MediatR;

namespace DevSkill.Application.Features.Course.GetCourse
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseVm>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseVm?> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);
            if(course == null)
            {
                return null;
            }
            var courseVm = _mapper.Map<CourseVm>(course);
            return courseVm;
       
        }
    }
}
