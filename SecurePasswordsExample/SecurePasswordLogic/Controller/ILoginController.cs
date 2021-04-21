namespace SecurePasswordLogic.Controller
{
    public interface ILoginController
    {
        bool Login(string username, string password);
    }
}