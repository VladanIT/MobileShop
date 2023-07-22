using Dapper;
using MobileShop.API.Data;
using MobileShop.API.Implementantions.Interfaces;
using MobileShop.API.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.API.Implementantions.Services
{
    //Prvo se nasledjuje Klasa (Samo jedna), a zatim interfejsi ( moze ih biti vise)
    public class UserServices : BaseServices, IUserInterface //F2 na naziv clase u koliko hoces da menjas svuda
    {
        public UserServices(MobileShopDbContex db, IConfiguration configuration) : base(db, configuration)
        {
        }

        public async Task CreateUser(User user)
        {
            var query = $@"INSERT INTO Users (Id, FirstName, LastName, Email, Password, Role)
                           VALUES(@Id, @FirstName, @LastName, @Email, @Password, @Role)";

            DynamicParameters parameters= new();
            parameters.Add("@Id", Guid.NewGuid());
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Role", user.Role);

            using(var conn = Connection)
            {
                await conn.QueryAsync<User>(query, parameters);
            }
        }

        public async Task DeleteUser(Guid id)
        {
            var query = $@"DELETE FROM Users
                           WHERE Id = @Id";

            DynamicParameters parameters= new();
            parameters.Add("@Id", id);

            using(var conn = Connection)
            {
                await conn.QueryAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = $@"SELECT *
                           FROM Users";

            //using var cnn = Connection;
            //Garbage collector
            using(var con = Connection)
            {
                return await con.QueryAsync<User>(query);
            }
        }

        public async Task<User> GetUserById(Guid id)
        {
            var query = $@"SELECT *
                           FROM Users
                           WHERE Id = @Id";

            DynamicParameters parameteres = new();
            parameteres.Add("@Id", id);

            using var con = Connection;
            return await con.QueryFirstOrDefaultAsync<User>(query, parameteres);
        }

        public async Task UpdateUser(Guid id, User user)
        {
            var query = $@"UPDATE Users
                           SET FirstName = @FirstName,
                               LastName = @LastName,
                               Email = @Email,
                               Password = @Password,
                               Role = @Role
                           WHERE Id = @Id";

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Role", user.Role);

            using (var conn = Connection)
            {
                await conn.QueryAsync<User>(query, parameters);
            }
        }
    }
}
