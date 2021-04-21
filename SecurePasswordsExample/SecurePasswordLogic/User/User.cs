namespace SecurePasswordLogic.User
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}