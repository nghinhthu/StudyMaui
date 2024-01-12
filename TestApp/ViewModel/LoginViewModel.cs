using AuthServices;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using TestApp.Helper.Logic;

namespace TestApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        LoginViewModelHelper _viewModelHelper;
        public LoginViewModel(LoginViewModelHelper viewModelHelper)
        {
            _userName = "nghinhthu";
            _viewModelHelper = viewModelHelper;
            //LoginCommand = new Command(Login);
        }
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        public string Message { get; set; }

        public ICommand LoginCommand => new Command(Login);



        private void Login(object obj)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Message = "Missing username/password";
                Shell.Current.DisplayAlert("Message", Message, "OK");
            }
            //BODataProcessResult result = _viewModelHelper.Login(UserName, Password).Result;
            BODataProcessResult result = Task.Run(async () => await _viewModelHelper.Login(UserName, Password)).Result;
            if (result.OK)
            {
                Shell.Current.DisplayAlert("Message", result.Message, "OK");
                Shell.Current.GoToAsync("MainPage");
            }
            else
            {
                Shell.Current.DisplayAlert("Message", result.Message, "OK");
            }
        }

    }
}
