using System.ComponentModel;
using System.Windows.Input;

namespace TestApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        public LoginViewModel()
        {
            UserName = "nghinhthu";
            Password = "123";
        }
        public string UserName
        {
            get => _userName; set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand LoginCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
