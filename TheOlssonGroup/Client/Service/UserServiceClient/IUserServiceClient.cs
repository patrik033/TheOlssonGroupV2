using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.UserServiceClient
{
    public interface IUserServiceClient
    {
        Task<ServiceResponse<string>> GetUserId(string userId);
        Task SaveUser(UserOrdersDto userOrdersDto);

    }
}
