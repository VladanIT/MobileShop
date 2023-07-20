using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MobileShop.API.Data;
using MobileShop.API.Model;
using System.Data;

namespace MobileShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly MobileShopDbContex _mobileShopDbContex;

        public UserController(IConfiguration configuration, MobileShopDbContex mobileShopDbContex)
        {
            _configuration = configuration;
            _mobileShopDbContex = mobileShopDbContex;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MobileShopConnectionString").ToString());
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<User> users = new List<User>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    User user = new User();
                    user.Id = (Guid)row["Id"];
                    user.FirstName = Convert.ToString(row["FirstName"]);
                    user.LastName = Convert.ToString(row["LastName"]);
                    user.Email = Convert.ToString(row["Email"]);
                    user.Password = Convert.ToString(row["Password"]);
                    user.Role = Convert.ToInt32(row["Role"]);
                    users.Add(user);
                }
            }

            return users;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            user.Id = Guid.NewGuid();
            await _mobileShopDbContex.Users.AddAsync(user);
            await _mobileShopDbContex.SaveChangesAsync();

            return Ok(user);
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
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User updateUser)
        {
            var user = await _mobileShopDbContex.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Id = updateUser.Id;
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.Role = updateUser.Role;

            await _mobileShopDbContex.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _mobileShopDbContex.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _mobileShopDbContex.Users.Remove(user);
            await _mobileShopDbContex.SaveChangesAsync();

            return Ok(user);
        }
    }
}
