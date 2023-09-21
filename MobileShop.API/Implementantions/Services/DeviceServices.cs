using Dapper;
using MobileShop.API.Data;
using MobileShop.API.Implementantions.Interfaces;
using MobileShop.API.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MobileShop.API.Implementantions.Services
{
    public class DeviceServices : BaseServices, IDeviceInterface
    {
        public DeviceServices(MobileShopDbContex db, IConfiguration configuration) : base(db, configuration)
        {
        }

        public async Task CreateDevice(Device device)
        {
            var query = $@"INSERT INTO Devices (Id, Brand, Model, Ram, Rom, Price)
                           VALUES (@Id, @Brand, @Model, @Ram, @Rom, @Price)";

            DynamicParameters parameters = new();
            parameters.Add("@Id", Guid.NewGuid());
            parameters.Add("@Brand", device.Brand);
            parameters.Add("@Model", device.Model);
            parameters.Add("@Ram", device.Ram);
            parameters.Add("@Rom", device.Rom);
            parameters.Add("@Price", device.Price);

            using (var conn = Connection)
            {
                await conn.QueryAsync(query, parameters);
            }
        }

        public async Task DeleteDevice(Guid id)
        {
            var query = $@"DELETE FROM Devices
                           WHERE Id = @Id";

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            using (var conn = Connection)
            {
                await conn.QueryAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            var query = $@"SELECT *
                           FROM Devices";

            //using var cnn = Connection;
            //Garbage collector
            using (var con = Connection)
            {
                return await con.QueryAsync<Device>(query);
            }
        }

        public async Task<Device> GetDeviceById(Guid id)
        {
            var query = $@"SELECT *
                           FROM Devices
                           WHERE Id = @Id";

            DynamicParameters parameteres = new();
            parameteres.Add("@Id", id);
            //using var cnn = Connection;
            //Garbage collector
            using (var con = Connection)
            {
                return await con.QueryFirstOrDefaultAsync<Device>(query, parameteres);
            }
        }

        public async Task UpdateDevice(Guid id, Device device)
        {
            var query = $@"UPDATE Devices
                           SET Brand = @Brand,
                               Model = @Model,
                               Ram = @Ram,
                               Rom = @Rom,
                               Price = @Price
                           WHERE Id = @Id";

            DynamicParameters parameters= new();
            parameters.Add("@Id", id);
            parameters.Add("@Brand", device.Brand);
            parameters.Add("@Model", device.Model);
            parameters.Add("@Ram", device.Ram);
            parameters.Add("@Rom", device.Rom);
            parameters.Add("@Price", device.Price);

            using (var conn = Connection)
            {
                await conn.QueryAsync<Device>(query, parameters);
            }
        }
    }
}
