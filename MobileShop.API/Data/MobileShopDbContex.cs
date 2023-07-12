using Microsoft.EntityFrameworkCore;
using MobileShop.API.Model;

namespace MobileShop.API.Data
{
    public class MobileShopDbContex : DbContext
    {
        public MobileShopDbContex(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Device> Devices { get; set; }
    }
}
