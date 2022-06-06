using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<string>> GetUserId(string userId);
    }
}
