using MaterialDesignX.ViewModels;

namespace MaterialDesignX;

public partial class UpdateProfilePage : ContentPage
{
    public UpdateProfilePage(UpdateProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}