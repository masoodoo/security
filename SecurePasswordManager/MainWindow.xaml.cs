using SecurePasswordManager.Models;
using SecurePasswordManager.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SecurePasswordManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnAddPassword.Click += AddPassword_Click;
            LoadPasswordList();
        }

        public void LoadPasswordList()
        {
            lstPasswords.ItemsSource = PasswordService.LoadPasswords(LoginWindow.MasterPassword);
            lstPasswords.Visibility = Visibility.Visible;
            MainFrame.Visibility = Visibility.Collapsed;
        }
        private void AddPassword_Click(object sender, RoutedEventArgs e)
        {
            var addPage = new AddPasswordPage();
            MainFrame.Navigate(addPage);
            MainFrame.Visibility = System.Windows.Visibility.Visible;
            lstPasswords.Visibility = System.Windows.Visibility.Collapsed;
        }
       
        public void ReturnFromAddPasswordPage()
        {
            LoadPasswordList();
        }
        private void LstPasswords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // کد مدیریت انتخاب آیتم
        }
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var changePassWindow = new ChangePasswordWindow();
            changePassWindow.Owner = this;
            changePassWindow.ShowDialog();
        }
        public void AddPasswordEntry(PasswordEntry entry)
        {
            var passwords = PasswordService.LoadPasswords(LoginWindow.MasterPassword);
            passwords.Add(entry);
            PasswordService.SavePasswords(passwords, LoginWindow.MasterPassword);
            LoadPasswordList();
        }

        public void UpdatePasswordList()
        {
            LoadPasswordList();
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            if (lstPasswords.SelectedItem is PasswordEntry selectedEntry)
            {
                MainFrame.Navigate(new AddPasswordPage(selectedEntry));
                MainFrame.Visibility = Visibility.Visible;
                lstPasswords.Visibility = Visibility.Collapsed;
            }
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (lstPasswords.SelectedItem is PasswordEntry selectedEntry)
            {
                var passwords = PasswordService.LoadPasswords(LoginWindow.MasterPassword);
                passwords.Remove(selectedEntry);
                PasswordService.SavePasswords(passwords, LoginWindow.MasterPassword);
                LoadPasswordList();
            }
        }
    }
}