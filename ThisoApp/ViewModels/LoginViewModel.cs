using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ThisoApp.Helper.Logic;

namespace ThisoApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {

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
            CustomerViewModelHelper viewModelHelper = new CustomerViewModelHelper();
            LoginViewModel result = Task.Run(async () => await viewModelHelper.LoginHelper(this)).Result;
            if (result != null)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Shell.Current.DisplayAlert("Message", "Login failed", "OK");
            }
            //Application.Current.MainPage = new AppShell();
        }
    }
}
