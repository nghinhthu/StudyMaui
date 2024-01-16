namespace ThisoApp.Views;

public partial class PromotionPage : ContentPage
{
    public PromotionPage()
    {
        InitializeComponent();
    }

    private void btnDetail_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PromotionDetailPage));
    }
}