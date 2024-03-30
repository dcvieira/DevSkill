using AutoMapper;
using DevSkill.Catalog.Application.Features.Categories.Queries.GetCategoriesList;
using DevSkill.Catalog.Application.Features.Category.Commands.CreateCategory;
using DevSkill.Catalog.Application.Features.Course.GetCourse;
using DevSkill.Catalog.Application.Features.Course.GetCoursesList;
using DevSkill.Catalog.Domain.Catalog.Entities;

namespace DevSkill.Catalog.Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
           
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryListVm>();


            CreateMap<Course, CourseListVm>();
            CreateMap<Course, CourseVm>();
        }

        
    }
}
