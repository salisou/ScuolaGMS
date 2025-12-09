using MauiApp.ViewModels;

namespace MauiApp.Pages;

public partial class MyTaskMain : ContentPage
{
    private MyTaskMainViewModel vm = new();
    public MyTaskMain()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        vm.UpdateData();
    }
}