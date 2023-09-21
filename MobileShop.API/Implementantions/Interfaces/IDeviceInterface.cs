using MobileShop.API.Model;

namespace MobileShop.API.Implementantions.Interfaces
{
    public interface IDeviceInterface
    {
        Task<IEnumerable<Device>> GetAllDevices();
        Task<Device> GetDeviceById(Guid Id);
        Task CreateDevice(Device device); //NapraviKorisnika (User user)
        Task UpdateDevice(Guid id, Device device);
        Task DeleteDevice(Guid id);
    }
}
