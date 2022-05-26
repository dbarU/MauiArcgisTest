namespace MauiArcgisTest
{
    using Esri.ArcGISRuntime;
    using Esri.ArcGISRuntime.Maui;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkitMarkup()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                   }).UseArcGISRuntime();
            builder.Services
                .AddTransient<IMauiInitializeService, ArcGISRuntimeInitializeService>();
            return builder.Build();
        }
        private class ArcGISRuntimeInitializeService : IMauiInitializeService
        {
            public void Initialize(IServiceProvider services)
            {
                ArcGISRuntimeEnvironment.ApiKey = "API_Key";
                ArcGISRuntimeEnvironment.Initialize();
            }
        }
    }
    
}