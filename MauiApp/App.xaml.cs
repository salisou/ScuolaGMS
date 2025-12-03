using MauiApp.Pages;

namespace MauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return base.CreateWindow(activationState);
        }
    }
}