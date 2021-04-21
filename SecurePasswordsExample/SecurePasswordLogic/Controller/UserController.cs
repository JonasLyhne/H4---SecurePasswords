using SecurePasswordLogic.Hashing;
using SecurePasswordLogic.User;
using SecurePasswordsDataAccess.Data;
using SecurePasswordsDataAccess.Databases;

namespace SecurePasswordLogic.Controller
{
    public class UserController : IUserController
    {
        private readonly IDataHandler _handler;
        // private readonly DataManager _handler;

        private readonly HashPassword _hasher;
        /// <summary>
        /// Tried to make this work using DI.
        /// But setting that up with .NET5 in a console is kinda tricky..
        /// </summary>
        /// <param name="handler"></param>
        // public UserController(IDataHandler handler)
        // {
        //     _handler = handler; 
        //     _hasher = new HashPassword();
        // }
        public UserController() 
        {
            IDataAccess cheatDependency = new SqlDataAccess(); // this is added because i couldn't make DI work
            _handler = new DataManager(cheatDependency); 
            _hasher = new HashPassword();
        }
        public bool CheckValidUsername(string username)
        {
            return _handler.UserExists(username);
        }

        public bool CreateUser(string username, string password)
        {
            var salt = HashPasswordExtensions.GenerateSalt();
            var hashedPassword = HashPasswordExtensions.HashToString(_hasher.HashWithPasswordSalt(password, salt, 50000)); // Change iterations to come from config file.
            return _handler.CreateUser(username, hashedPassword, HashPasswordExtensions.HashToString(salt));
        }

        public bool UserLogin(string username, string password)
        {
            if (!CheckValidUsername(username))
            {
                return false;
            }

            var salt = _handler.GetSaltByUsername(username);
            var saltToByteArray = HashPasswordExtensions.GetByteArrayFromString(salt);
            var validationPass = HashPasswordExtensions.HashToString(_hasher.HashWithPasswordSalt(password, saltToByteArray, 50000));
            return _handler.ValidateUser(username, validationPass);
        }
        
    }
}