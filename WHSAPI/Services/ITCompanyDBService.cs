using Microsoft.EntityFrameworkCore;
using WHSAPI.Context;

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
}