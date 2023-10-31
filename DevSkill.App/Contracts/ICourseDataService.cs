using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts;
public interface ICourseDataService
{
    Task<List<CourseViewModel>> GetAllCourses();
    Task<CourseVm> GetCourse(Guid courseId);
}

