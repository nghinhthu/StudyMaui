using AuthServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        public string Message { get; set; }

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Message = "Missing username/password";
                Shell.Current.DisplayAlert("Message", Message, "OK");
            }
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
