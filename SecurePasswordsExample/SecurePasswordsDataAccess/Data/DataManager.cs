namespace SecurePasswordsDataAccess.Data
{
    using System.Linq;
    using Databases;
    using Models;
    
    public class DataManager : IDataHandler
    {
        private readonly IDataAccess _db;
        private const string MainTable = "dbo.Users";
        private const string ConnectionString = "Server=.;Database=SecurePasswords;Trusted_Connection=True;";

        public DataManager(IDataAccess db)
        {
            _db = db;
        }
        public UserModel GetUserById(int id)
        {
            var sql = $"SELECT * FROM {MainTable} WHERE Id = @Id";
            return _db.LoadData<UserModel, dynamic>(sql, new { id }, ConnectionString, false).FirstOrDefault();
        }
        
        public UserModel GetUserByUserName(string username)
        {
            var sql = $"SELECT u.username FROM {MainTable} u WHERE Username = @Username";
            return _db.LoadData<UserModel, dynamic>(sql, new { username }, ConnectionString, false).FirstOrDefault();
        }

        public bool CreateUser(string username, string password, string salt)
        {
           return _db.LoadData<bool, dynamic>("dbo.Users_Insert", 
                new {Username = username, Password = password, Salt = salt},
                ConnectionString,
                true).FirstOrDefault();
        }

        public bool UserExists(string username)
        {
            var sql = $"SELECT 1 FROM {MainTable} WHERE Username = @Username";
            return _db.LoadData<bool, dynamic>(sql, new { username }, ConnectionString, false).FirstOrDefault();
        }

        public string GetSaltByUsername(string username)
        {
            var sql = $"SELECT Salt FROM {MainTable} WHERE Username = @username";
            return _db.LoadData<string, dynamic>(sql, new { username }, ConnectionString, false).FirstOrDefault();
        }

        public bool ValidateUser(string username, string password)
        {
            var sql = $"SELECT 1 FROM {MainTable} WHERE Username = @Username AND [Password] = @Password";
            return _db.LoadData<bool, dynamic>(sql, new {username, password}, ConnectionString, false)
                .FirstOrDefault();
        }
    }
}