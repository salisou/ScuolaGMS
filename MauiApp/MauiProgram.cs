namespace MauiApp
{
    public static class MauiProgram
    {
        public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
        {
            var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("Roboto-Italic.ttf", "Italic");
                    fonts.AddFont("Roboto-Medium.ttf", "Roboto");
                    fonts.AddFont("Epilogue-Regular.ttf", "Epilogue");
                });

            return builder.Build();
        }
    }
}
