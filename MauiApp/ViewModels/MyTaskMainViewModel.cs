using MauiApp.Models;
using System.Collections.ObjectModel;

namespace MauiApp.ViewModels
{
    public class MyTaskMainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public MyTaskMainViewModel()
        {
            FillData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new() {
                        Id = 1,
                        CategoryName = ".NET MAUI Course",
                        Color = "#CF14DF"
                },
                new() {
                        Id = 2,
                        CategoryName = "Tutorials",
                        Color = "#df6f14"
                },
                new() {
                        Id = 3,
                        CategoryName = "Shopping",
                        Color = "#14df80"
                }
            };
        }
    }
}
