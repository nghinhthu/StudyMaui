using MaterialDesignX.Helper.Logic;
using MaterialDesignX.Services;
using MaterialDesignX.ViewModels;

namespace MaterialDesignX
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                });
            builder.Services.AddSingleton<UpdateProfileViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<CustomerViewModelHelper>();
            builder.Services.AddSingleton<UpdateProfilePage>();
            builder.Services.AddSingleton<LoginPage>();

            return builder.Build();
        }
    }
}