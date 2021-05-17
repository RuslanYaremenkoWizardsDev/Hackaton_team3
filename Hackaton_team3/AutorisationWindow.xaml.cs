using System.Windows;

namespace Hackaton_team3
{
    /// <summary>
    /// Interaction logic for AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        public AutorisationWindow()
        {
            InitializeComponent();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }

        private void Button_Forgot_Password_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.Show();
            this.Hide();
        }

        private void Button_Main_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
