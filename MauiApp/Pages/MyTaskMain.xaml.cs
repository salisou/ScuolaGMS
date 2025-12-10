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

    private void btnNewTask_Clicked(object sender, EventArgs e)
    {
        var taskName = new AddTaskPage
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = vm.Tasks,
                Categories = vm.Categories
            }
        };

        Navigation.PushModalAsync(taskName);
    }
}