using MauiApp.Models;
using MauiApp.ViewModels;

namespace MauiApp.Pages;

public partial class AddTaskPage : ContentPage
{
    public AddTaskPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        var selectCategory =
            vm!.Categories.Where(c => c.IsSelected == true).FirstOrDefault();

        if (selectCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectCategory.Id,
            };
            vm.Tasks.Add(task);
            await Navigation.PopModalAsync();
        }
        else
        {
            await DisplayAlertAsync("Invalide selection", "You must select  a category", "OK");
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }
}