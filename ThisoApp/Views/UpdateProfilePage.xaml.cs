using ThisoApp.ViewModels;

namespace ThisoApp.Views;

public partial class UpdateProfilePage : ContentPage
{
    UpdateProfileViewModel viewModel;
    public UpdateProfilePage(UpdateProfileViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetProfile();
        this.BindingContext = viewModel;
    }
}