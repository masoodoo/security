using SecurePasswordManager.Models;
using System.Windows.Input;

namespace SecurePasswordManager.ViewModels
{
    public class AddPasswordViewModel
    {
        public PasswordEntry Entry { get; set; }
        public ICommand SaveCommand { get; }

        public AddPasswordViewModel(PasswordEntry entry)
        {
            Entry = entry;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            // منطق ذخیره‌سازی
        }
    }
}