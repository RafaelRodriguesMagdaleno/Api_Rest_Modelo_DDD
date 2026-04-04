using Microsoft.AspNetCore.Mvc;
using Unibet.DTOs;
using Unibet.Entities;
using Unibet.Interfaces.IServices;

namespace Unibet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUserData")]
        public IActionResult GetUserData([FromQuery] int Id)
        {
            User userRespose = _service.GetUserData(Id);
            return Ok(userRespose);
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] DepositDTO deposit)
        {
            try
            {
                _service.Deposit(deposit);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit")]
        public IActionResult GetUserData([FromQuery] int Id, [FromBody] DepositDTO deposit)
        {
            User userRespose = _service.GetUserData(Id);
            return Ok(userRespose);
        }
    }
}
