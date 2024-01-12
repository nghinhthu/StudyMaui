namespace TestApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("KeypadPage", typeof(KeypadPage));
            Routing.RegisterRoute("HslPage", typeof(HslPage));
        }
    }
}