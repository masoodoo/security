using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurePasswordManager.Models
{
    public class PasswordEntry : INotifyPropertyChanged
    {
        private string _name;
        private string _username;
        private string _password;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}