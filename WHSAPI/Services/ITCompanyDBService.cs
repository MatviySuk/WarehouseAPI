using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WHSAPI.Context;
using WHSAPI.Entities;
using WHSAPI.ViewModels;

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

    public async Task<OLTPMetadata> GetOLTPDBMetadata()
    {
        var meta = new OLTPMetadata();

        meta.DbName = context.Database.GetDbConnection().Database;

        meta.TablesInfo["DelayReason"] = context.DelayReasons.Count();
        meta.TablesInfo["Employee"] = context.Employees.Count();
        meta.TablesInfo["EmployeeRole"] = context.EmployeeRoles.Count();
        meta.TablesInfo["Industry"] = context.Industries.Count();
        meta.TablesInfo["Platform"] = context.Platforms.Count();
        meta.TablesInfo["Priority"] = context.Priorities.Count();
        meta.TablesInfo["Project"] = context.Projects.Count();
        meta.TablesInfo["ProjectCategory"] = context.ProjectCategories.Count();
        meta.TablesInfo["ProjectPlatform"] = context.ProjectPlatforms.Count();
        meta.TablesInfo["ProjectRegion"] = context.ProjectRegions.Count();
        meta.TablesInfo["ProjectStatus"] = context.ProjectStatuses.Count();
        meta.TablesInfo["Region"] = context.Regions.Count();
        meta.TablesInfo["Role"] = context.Roles.Count();
        meta.TablesInfo["Tasks"] = context.Tasks.Count();
        meta.TablesInfo["TasksStatus"] = context.TaskStatuses.Count();
        meta.TablesInfo["TaskType"] = context.TaskTypes.Count();
        meta.TablesInfo["Team"] = context.Teams.Count();
        meta.TablesInfo["TeamEmployees"] = context.TeamEmployees.Count();
        meta.TablesInfo["TeamType"] = context.TeamTypes.Count();
        meta.TablesInfo["WorkCategory"] = context.WorkCategories.Count();
        meta.TablesInfo["WorkComment"] = context.WorkComments.Count();
        meta.TablesInfo["WorkResult"] = context.WorkResults.Count();
        meta.TablesInfo["WorksWithTasks"] = context.WorksWithTasks.Count();

        return meta;
    }

}