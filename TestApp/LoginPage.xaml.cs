using TestApp.ViewModel;

namespace TestApp;

public partial class LoginPage : ContentPage
{
    private LoginViewModel viewModel;
    public LoginPage(LoginViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
    }

    private void Login(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(viewModel.UserName) || string.IsNullOrEmpty(viewModel.Password))
        {
            viewModel.Message = "Missing username/password";
            return;
        }
        else
        {

        }

    }
}