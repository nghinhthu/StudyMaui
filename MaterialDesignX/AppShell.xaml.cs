namespace MaterialDesignX
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("UpdateProfilePage", typeof(UpdateProfilePage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        }
    }
}