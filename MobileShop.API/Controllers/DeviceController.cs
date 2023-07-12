using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MobileShop.API.Data;
using MobileShop.API.Model;
using System.Data;
using System.Text.Json;

namespace MobileShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly MobileShopDbContex _mobileShopDbContex;
        public DeviceController(IConfiguration configuration, MobileShopDbContex mobileShopDbContex) 
        {
            _configuration = configuration;
            _mobileShopDbContex= mobileShopDbContex;
        }

        [HttpGet]
        public string GetDevices()
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MobileShopConnectionString").ToString());
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Devices", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Device> devices = new List<Device>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Device device = new Device();
                    device.Id = (Guid)row["Id"];
                    device.Brand = Convert.ToString(row["Brand"]);
                    device.Model = Convert.ToString(row["Model"]);
                    device.Ram = Convert.ToInt32(row["Ram"]);
                    device.Rom = Convert.ToInt32(row["Rom"]);
                    device.Price = Convert.ToInt32(row["Price"]);
                    devices.Add(device);
                }
            }

            return JsonSerializer.Serialize(devices);

        }

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device deviceRequest)
        {
            deviceRequest.Id = Guid.NewGuid();
            await _mobileShopDbContex.Devices.AddAsync(deviceRequest);
            await _mobileShopDbContex.SaveChangesAsync();

            return Ok(deviceRequest);
        }
    }
}
