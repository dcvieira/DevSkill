using AutoMapper;
using Blazored.LocalStorage;
using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Services
{
    public class CourseDataService : BaseDataService, ICourseDataService
    {
        private readonly IMapper _mapper;

        public CourseDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            var allCourses = await _client.GetAllCoursesAsync();
            var mappedCourses = _mapper.Map<ICollection<CourseViewModel>>(allCourses);
            return mappedCourses.ToList();
        }

        public async Task<CourseVm> GetCourse(Guid courseId)
        {
            CourseVm course = await _client.GetCourseAsync(courseId);
            return course;
        }
    }
}
