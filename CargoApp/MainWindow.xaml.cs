using System.Windows;

namespace CargoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayLoginWindow();
        }

        private void DisplayLoginWindow()
        {
            // Открываем окно авторизации
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (App.CurrentUser != null)
            {
                WelcomeMessage.Text = $"Здравствуйте, {App.CurrentUser.Name}";

                // Настраиваем видимость кнопок
                if (App.CurrentUser.Role == "Администратор")
                {
                    RegisterButton.Visibility = Visibility.Visible;
                    AdminPanelButton.Visibility = Visibility.Visible;
                    UserStatisticsButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    RegisterButton.Visibility = Visibility.Collapsed;
                    AdminPanelButton.Visibility = Visibility.Collapsed;
                    UserStatisticsButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // Если пользователь не авторизовался, завершаем приложение
                Application.Current.Shutdown();
            }
        }

        private void PersonalCabinet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыт личный кабинет.");
        }

        private void RegisterUsers_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыто окно регистрации пользователей.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Сбрасываем текущего пользователя
            App.CurrentUser = null;

            // Скрываем главное окно
            this.Hide();

            // Открываем окно авторизации
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            // Если пользователь снова авторизовался, показываем главное окно
            if (App.CurrentUser != null)
            {
                this.Show();
                WelcomeMessage.Text = $"Здравствуйте, {App.CurrentUser.Name}";

                // Настраиваем видимость кнопок
                if (App.CurrentUser.Role == "Администратор")
                {
                    RegisterButton.Visibility = Visibility.Visible;
                    AdminPanelButton.Visibility = Visibility.Visible;
                    UserStatisticsButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    RegisterButton.Visibility = Visibility.Collapsed;
                    AdminPanelButton.Visibility = Visibility.Collapsed;
                    UserStatisticsButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // Если пользователь не авторизовался, закрываем приложение
                Application.Current.Shutdown();
            }
        }


        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыта панель администратора.");
        }

        private void UserStatistics_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыта статистика пользователя.");
        }
    }
}
