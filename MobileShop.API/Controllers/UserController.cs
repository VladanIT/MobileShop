using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MobileShop.API.Data;
using MobileShop.API.Implementantions.Interfaces;
using MobileShop.API.Model;
using System.Data;

namespace MobileShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly MobileShopDbContex _mobileShopDbContex;
        private readonly IUserInterface _userInterface;

        public UserController(MobileShopDbContex mobileShopDbContex, IUserInterface userInterface)
        {
            _mobileShopDbContex = mobileShopDbContex;
            _userInterface = userInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userInterface.GetAllUsers();

            return Ok(result);
        }

        [HttpPost]
        public async Task AddUser([FromBody] User user)
        {
            await _userInterface.CreateUser(user);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _mobileShopDbContex.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task UpdateUser([FromRoute] Guid id, User updateUser)
        {
            await _userInterface.UpdateUser(id, updateUser);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task DeleteUser([FromRoute] Guid id)
        {
            await _userInterface.DeleteUser(id);
        }
    }
}
