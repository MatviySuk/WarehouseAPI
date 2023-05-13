using AutoMapper;
using WHSAPI.Entities;
using WHSAPI.ViewModels;

namespace WHSAPI;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<DimDate, DimDateView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.DateKey))
            .ReverseMap();
        CreateMap<DimDate, DimDate>().ReverseMap();
        
        CreateMap<DimRole, DimRoleView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.RoleKey))
            .ReverseMap();
        CreateMap<DimRole, DimRole>().ReverseMap();

        CreateMap<DimEmployee, DimEmployeeView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.EmployeeKey))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleKeyNavigation))
            .ReverseMap();
        CreateMap<DimEmployee, DimEmployee>().ReverseMap();
        
        CreateMap<DimIndustry, DimIndustryView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.IndustryKey))
            .ReverseMap();
        CreateMap<DimRole, DimRole>().ReverseMap();

        CreateMap<DimProject, DimProjectView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ProjectKey))
            .ForMember(dest => dest.ProjectManager, opt => opt.MapFrom(src => src.ProjectManagerKeyNavigation))
            .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.IndustryKeyNavigation))
            .ReverseMap();
        CreateMap<DimProject, DimProject>().ReverseMap();

        CreateMap<FactWorksWithTask, FactWorksWithTaskView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.WorksKey))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.EmployeeKeyNavigation))
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.ProjectKeyNavigation))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDateKeyNavigation))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDateKeyNavigation))
            .ReverseMap();
        CreateMap<FactWorksWithTask, FactWorksWithTask>().ReverseMap();
    }
}