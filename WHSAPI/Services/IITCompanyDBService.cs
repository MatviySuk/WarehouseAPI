using WHSAPI.Entities;

namespace WHSAPI.Services;

public interface IITCompanyDBService
{
    public Task<int> FullLoadWHS();

    public Task<int> UpdateNewWHS();
    
    public Task<int> WHSCleanUp();

    public Task<DateTime> LastLoad();
}