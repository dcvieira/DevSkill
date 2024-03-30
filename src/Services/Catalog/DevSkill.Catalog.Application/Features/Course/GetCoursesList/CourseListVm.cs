namespace DevSkill.Catalog.Application.Features.Course.GetCoursesList;
public class CourseListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

