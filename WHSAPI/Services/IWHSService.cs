using WHSAPI.Entities;

namespace WHSAPI.Services;

public interface IWHSService
{
    public Task<IList<FactWorksWithTask>> GetAll();
}