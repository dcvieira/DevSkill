using AutoMapper;
using DevSkill.App.ViewModels;
using DevSkill.App.Services.Base;


namespace DevSkill.App.Profiles;
public class Mappings : Profile
{
    public Mappings()
    {
        //Vms are coming in from the API, ViewModel are the local entities in Blazor

        CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
        CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();

        CreateMap<CreateOrderCommand, CreateOrderViewModel>().ReverseMap();

        CreateMap<CourseListVm, CourseViewModel>().ReverseMap();


    }
}
