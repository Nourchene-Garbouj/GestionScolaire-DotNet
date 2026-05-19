using DS_.net.Business;
using System.Windows;

namespace DS_.net.Views
{
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService = new AuthService();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtLogin.Text.Trim();
            string password = TxtPassword.Password.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                TxtError.Text = "Veuillez remplir tous les champs.";
                return;
            }

            var user = _authService.Login(login, password);

            if (user == null)
            {
                TxtError.Text = "Login ou mot de passe incorrect.";
                return;
            }

            var mainWindow = new CrudWindow(user.Role);
            mainWindow.Show();
            this.Close();
        }
    }
}