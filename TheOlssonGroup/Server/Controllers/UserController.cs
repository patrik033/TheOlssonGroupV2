using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheOlssonGroup.Contracts.Service.UserService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly OlssonContext _context;

        public UserController(IUserService service, IMapper mapper, OlssonContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult> Save(UserOrdersDto ordersDto)
        {
            var userOrders = _mapper.Map<UserOrder>(ordersDto);
            _context.UserOrders.Add(userOrders);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<string>>> GetUserId(string userId)
        {
            var result = await _service.GetUserId(userId);
            return Ok(result);
        }
    }
}
