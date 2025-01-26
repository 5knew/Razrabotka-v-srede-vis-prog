using System.Windows;

namespace CargoApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (AuthService.Authenticate(username, password, out User authenticatedUser))
            {
                App.CurrentUser = authenticatedUser;
                this.Close(); // Закрываем окно после успешной авторизации
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Завершаем приложение, если пользователь нажал "Отмена"
        }
    }
}
