using MauiApp.Pages;

namespace MauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MyTaskMain());
            //MainPage = new AddTask();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return base.CreateWindow(activationState);
        }
    }
}