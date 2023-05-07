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
            .Include(f => f.TaskKeyNavigation)
            .ThenInclude(ts => ts.ProjectKeyNavigation)
            .ToListAsync();
    }
}