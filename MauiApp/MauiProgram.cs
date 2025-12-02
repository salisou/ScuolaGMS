namespace MauiApp
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
                    fonts.AddFont("Roboto-Italic.ttf", "Italic");
                    fonts.AddFont("Roboto-Medium.ttf", "Medium");
                });

            return builder.Build();
        }
    }
}