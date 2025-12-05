using MauiApp.ViewModels;

namespace MauiApp.Pages;

public partial class MyTaskMain : ContentPage
{
    public MyTaskMain()
    {
        InitializeComponent();
        BindingContext = new MyTaskMainViewModel();
    }
}