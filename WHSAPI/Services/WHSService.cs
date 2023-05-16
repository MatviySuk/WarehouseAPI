using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WHSAPI.Context;
using WHSAPI.Entities;

namespace WHSAPI.Services;

public class WHSService: IWHSService
{
    private readonly WHSDbContext context;
    private readonly IMapper mapper;

    public WHSService(WHSDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    
    public async Task<IList<FactWorksWithTask>> GetAll()
    {
        return await context.FactWorksWithTasks
            .Include(f => f.StartDateKeyNavigation)
            .Include(f => f.EndDateKeyNavigation)
            .Include(f => f.EmployeeKeyNavigation)
            .ThenInclude(emp => emp.RoleKeyNavigation)
            .Include(f => f.ProjectKeyNavigation)
            .ThenInclude(p => p.IndustryKeyNavigation)
            .ToListAsync();
    }

    public async Task<IList<DimDate>> GetAllDates()
    {
        return await context.DimDates.ToListAsync();
    }
}