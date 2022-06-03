using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOlssonGroup.Contracts.Service.UserService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly OlssonContext _context;

        public UserService(OlssonContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> GetUserId(string userId)
        {
            var result = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == userId);
            var correctId = result?.Id;
            var resultService = new ServiceResponse<string>
            {
                Data = correctId,
                Success = true,
                Message = "Success"
            };
            return resultService;
        }

        public Task<ServiceResponse<UserOrder>> Save(UserOrder userOrdersDto)
        {
            throw new NotImplementedException();
        }
    }
}
