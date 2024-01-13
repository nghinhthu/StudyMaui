using Microsoft.Extensions.Logging;
using TestApp.Helper.Logic;
using TestApp.Services;
using TestApp.ViewModel;

namespace TestApp
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
                });
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<APILoginService>();

            builder.Services.AddSingleton<LoginViewModelHelper>();

            builder.Services.AddSingleton<LoginPage>();
            //builder.Services.AddSingleton<HttpClient>();
            //builder.Services.AddHttpClient(AppConstant.APIServiceName, httpClient =>
            //{
            //    var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7139" :
            //    "https://localhost:7139";
            //    httpClient.BaseAddress = new Uri(baseAddress);
            //    httpClient.DefaultRequestHeaders.Clear();
            //    httpClient.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //});

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}