using SecurePasswordsDataAccess.Models;

namespace SecurePasswordsDataAccess.Data
{
    public interface IDataHandler
    {
        UserModel GetUserById(int id);
        UserModel GetUserByUserName(string username);
        bool CreateUser(string username, string password, string salt);
        bool UserExists(string username);
        string GetSaltByUsername(string username);
        bool ValidateUser(string username, string password);
    }
}