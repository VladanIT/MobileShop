using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileShop.API.Data;
using MobileShop.API.Model;
using System.Data;
using MobileShop.API.Implementantions.Interfaces;

namespace MobileShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly MobileShopDbContex _mobileShopDbContex;
        private readonly IDeviceInterface _deviceInterface;

        public DeviceController(IDeviceInterface deviceInterface, MobileShopDbContex mobileShopDbContex) 
        {
            _mobileShopDbContex= mobileShopDbContex;
            _deviceInterface = deviceInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var result = await _deviceInterface.GetAllDevices();

            return Ok(result);
        }

        [HttpPost]
        public async Task AddDevice([FromBody] Device deviceRequest)
        {
            await _deviceInterface.CreateDevice(deviceRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDevice([FromRoute] Guid id)
        {
            var result = await _deviceInterface.GetDeviceById(id);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task UpdateDevice([FromRoute] Guid id, Device updateDevice)
        {
            await _deviceInterface.UpdateDevice(id, updateDevice);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task DeleteDevice([FromRoute] Guid id)
        {
            await _deviceInterface.DeleteDevice(id);
        }
    }
}
