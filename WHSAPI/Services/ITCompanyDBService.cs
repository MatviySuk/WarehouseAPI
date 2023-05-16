using Microsoft.EntityFrameworkCore;
using WHSAPI.Context;
using WHSAPI.Entities;

namespace WHSAPI.Services;

public class ITCompanyDBService: IITCompanyDBService
{
    private readonly ITCompanyDbContext context;

        
    public ITCompanyDBService(ITCompanyDbContext context)
    {
        this.context = context;
    }
    
    public async Task<int> FullLoadWHS()
    {
        return await context.Database.ExecuteSqlAsync($"exec dbo.ManualETLFullLoad");
    }

    public async Task<int> UpdateNewWHS()
    {
        return await context.Database.ExecuteSqlAsync($"exec dbo.ManualETLNewUpdate");
    }

    public async Task<int> WHSCleanUp()
    {
        return await context.Database.ExecuteSqlAsync($"exec dbo.WarehouseCleanUp");
    }

    
    public async Task<DateTime> LastLoad()
    {
        var first = await context.StagingLoads.FirstAsync();

        return first.LoadDatetime;
    }
}