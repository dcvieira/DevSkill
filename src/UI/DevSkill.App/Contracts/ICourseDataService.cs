
using DevSkill.App.Services.Base.Catalog;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts;
public interface ICourseDataService
{
    Task<List<CourseViewModel>> GetAllCourses();
    Task<CourseVm> GetCourse(Guid courseId);
}

