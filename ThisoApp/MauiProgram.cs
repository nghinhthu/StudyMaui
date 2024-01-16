using Microsoft.Extensions.Logging;
using ThisoApp.Helper.Logic;
using ThisoApp.Services;
using ThisoApp.ViewModels;
using ThisoApp.Views;

namespace ThisoApp
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
                    fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
                });
            builder.Services.AddSingleton<UpdateProfileViewModel>();
            builder.Services.AddSingleton<NewsViewModel>();
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<NewsService>();
            builder.Services.AddSingleton<CustomerViewModelHelper>();
            builder.Services.AddSingleton<NewsViewModelHelper>();
            builder.Services.AddSingleton<UpdateProfilePage>();
            builder.Services.AddSingleton<NewsPage>();
            //builder.Services.AddSingleton<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}