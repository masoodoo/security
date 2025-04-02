using System.Windows;
using SecurePasswordManager.Services;

namespace SecurePasswordManager
{
   
        public partial class LoginWindow : Window
        {
            // رمز اصلی برنامه (موقت - در نسخه نهایی باید از روش امن‌تری استفاده کنید)
            private const string CorrectPassword = "masood1234";

            public static string MasterPassword { get; private set; }

            public LoginWindow()
            {
                InitializeComponent();
            }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordConfigService.VerifyPassword(txtMasterPassword.Password))
            {
                MasterPassword = txtMasterPassword.Password;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("رمز عبور نامعتبر است", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
