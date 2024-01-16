using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignX.Helper.Logic;

namespace MaterialDesignX.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {

        }
        //private CustomerViewModelHelper _viewModelHelper;
        //public LoginViewModel(CustomerViewModelHelper viewModelHelper)
        //{
        //    _viewModelHelper = viewModelHelper;
        //}


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
                Shell.Current.GoToAsync("UpdateProfilePage");
            }
            else
            {
                Shell.Current.DisplayAlert("Message", "Login failed", "OK");
            }
        }
    }
}
