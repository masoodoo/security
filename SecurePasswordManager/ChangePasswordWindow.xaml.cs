using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SecurePasswordManager.Services;
namespace SecurePasswordManager
{
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("رمزهای جدید مطابقت ندارند");
                return;
            }

            // فراخوانی متد تغییر رمز
            bool success = PasswordService.ChangeMasterPassword(
                txtCurrentPassword.Password,
                txtNewPassword.Password);

            if (success)
            {
                MessageBox.Show("رمز عبور با موفقیت تغییر یافت");
                this.Close();
            }
            else
            {
                MessageBox.Show("تغییر رمز ناموفق بود. رمز فعلی را بررسی کنید");
            }
        }
    }
}