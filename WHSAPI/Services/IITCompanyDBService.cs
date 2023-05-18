using WHSAPI.Entities;
using WHSAPI.ViewModels;

namespace WHSAPI.Services;

public interface IITCompanyDBService
{
    public Task<int> FullLoadWHS();

    public Task<int> UpdateNewWHS();
    
    public Task<int> WHSCleanUp();

    public Task<DateTime> LastLoad();

    public Task<OLTPMetadata> GetOLTPDBMetadata();
}