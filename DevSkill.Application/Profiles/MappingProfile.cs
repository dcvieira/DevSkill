using AutoMapper;
using DevSkill.Application.Features.Categories.Queries.GetCategoriesList;
using DevSkill.Application.Features.Category.Commands.CreateCategory;
using DevSkill.Application.Features.Course.GetCourse;
using DevSkill.Application.Features.Course.GetCoursesList;
using DevSkill.Application.Features.Order.Queries.GetOrderByCourse;
using DevSkill.Application.Features.Order.Queries.GetOrdersList;
using DevSkill.Domain.Catalog.Entities;
using DevSkill.Domain.Order.Entities;

namespace DevSkill.Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
           
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryListVm>();

            CreateMap<Order, OrdersListVm>();
            CreateMap<Order, OrderVm>();


            CreateMap<Course, CourseListVm>();
            CreateMap<Course, CourseVm>();
        }

        
    }
}
