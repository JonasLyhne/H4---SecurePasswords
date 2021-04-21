using SecurePasswordLogic.User;

namespace SecurePasswordLogic.Controller
{
    public interface IUserController
    {
        bool CheckValidUsername(string username);

        bool CreateUser(string username, string password);
        
        bool UserLogin(string username, string password);
    }
}