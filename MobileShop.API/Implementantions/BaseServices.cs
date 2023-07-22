using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MobileShop.API.Data;

namespace MobileShop.API.Implementantions
{
    public abstract class BaseServices
    {
        private readonly MobileShopDbContex _db;
        private readonly IConfiguration _configuration; // pristup Appssetings
        protected BaseServices(MobileShopDbContex db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        protected SqlConnection Connection => new SqlConnection(_configuration.GetConnectionString("MobileShopConnectionString").ToString());
    }
}
