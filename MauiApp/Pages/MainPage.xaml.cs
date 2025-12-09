namespace MauiApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void btnTest_Clicked(object sender, EventArgs e)
    {
        DisplayAlertAsync("Alert", "Button Clicked!", "OK");
    }

    private void ibtnDot_Clicked(object sender, EventArgs e)
    {
        btnTest.BackgroundColor = Colors.Red;
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        DisplayAlertAsync("Attenzione!", $"Change: {e.Value}", "Ok");
    }

    private void ricercaControl_SearchButtonPressed(object sender, EventArgs e)
    {
        DisplayAlertAsync("Ricerca", $"Searching: {ricercaControl.Text}", "OK");
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {
        DisplayAlertAsync("Swipe", "Swipe Item Invoked", "OK");
    }

    private void SwipeItem_Invoked_1(object sender, EventArgs e)
    {
        DisplayAlertAsync("Swipe", "Delete Item Invoked", "OK");
    }
}