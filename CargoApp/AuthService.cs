namespace CargoApp
{
    public static class AuthService
    {
        private static readonly User[] Users =
        {
            new User { Username = "admin", Password = "admin123", Name = "Администратор", Role = "Администратор" },
            new User { Username = "user1", Password = "user123", Name = "Иван Иванов", Role = "Пользователь" },
            new User { Username = "user2", Password = "user456", Name = "Мария Петрова", Role = "Пользователь" }
        };

        public static bool Authenticate(string username, string password, out User authenticatedUser)
        {
            authenticatedUser = null;
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    authenticatedUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}
