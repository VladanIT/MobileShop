using MobileShop.API.Model;

namespace MobileShop.API.Implementantions.Interfaces
{
    public interface IUserInterface
    {
        //Potpisi metoda ( Nazivi )
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task CreateUser(User user); //NapraviKorisnika (User user)
        Task UpdateUser(Guid id, User user);
        Task DeleteUser(Guid id);
    }
}
