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

        CreateMap<DimProject, DimProjectView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ProjectKey))
            .ForMember(dest => dest.ProjectManager, opt => opt.MapFrom(src => src.ProjectManagerKeyNavigation))
            .ReverseMap();
        CreateMap<DimProject, DimProject>().ReverseMap();

        CreateMap<DimTask, DimTaskView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.TaskKey))
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.ProjectKeyNavigation))
            .ReverseMap();
        CreateMap<DimTask, DimTask>().ReverseMap();

        CreateMap<FactWorksWithTask, FactWorksWithTaskView>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.WorkKey))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.EmployeeKeyNavigation))
            .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.TaskKeyNavigation))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDateKeyNavigation))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDateKeyNavigation))
            .ReverseMap();
        CreateMap<FactWorksWithTask, FactWorksWithTask>().ReverseMap();
    }
}