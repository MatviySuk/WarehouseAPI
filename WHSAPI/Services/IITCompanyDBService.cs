namespace WHSAPI.Services;

public interface IITCompanyDBService
{
    public Task<int> FullLoadWHS();

    public Task<int> UpdateNewWHS();
}