using SecurePasswordManager.Models;
using SecurePasswordManager.Services;
using System.Windows;
using System.Windows.Controls;


namespace SecurePasswordManager
{
    public partial class AddPasswordPage : Page
    {
        public AddPasswordPage()
        {
            InitializeComponent();
        }
        private void SavePassword_Click(object sender, RoutedEventArgs e)
        {
            // 1. ذخیره اطلاعات
            var encrypted = CryptoHelper.Encrypt(txtPassword.Password, LoginWindow.MasterPassword);

            var newEntry = new PasswordEntry
            {
                Name = txtServiceName.Text,
                EncryptedPassword = encrypted.EncryptedData,
                Salt = encrypted.Salt,
                IV = encrypted.IV
            };

            var passwords = PasswordService.LoadPasswords(LoginWindow.MasterPassword);
            passwords.Add(newEntry);
            PasswordService.SavePasswords(passwords, LoginWindow.MasterPassword);

            // 2. بازگشت به صفحه اصلی و به‌روزرسانی لیست
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.ReturnFromAddPasswordPage();
            }

            // 3. اگر از Navigation استفاده می‌کنید
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

    }
}