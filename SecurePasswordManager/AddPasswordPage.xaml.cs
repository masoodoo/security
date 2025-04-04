using SecurePasswordManager.Models;
using SecurePasswordManager.Services;
using SecurePasswordManager.ViewModels;
using System.Windows;
using System.Windows.Controls;



namespace SecurePasswordManager
{
    public partial class AddPasswordPage : Page
    {
        public AddPasswordPage()
        {
            InitializeComponent(); // این خط باید اولین خط در constructor باشد
        }

        public AddPasswordPage(PasswordEntry entry) : this()
        {
            // مقداردهی اولیه با entry
            txtServiceName.Text = entry.Name;
            txtUsername.Text = entry.Username;
            txtPassword.Password = entry.Password;
        }
    }


}
    }

