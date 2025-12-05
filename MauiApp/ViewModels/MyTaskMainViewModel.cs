using MauiApp.Models;
using System.Collections.ObjectModel;

namespace MauiApp.ViewModels
{
    public class MyTaskMainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Mytasks { get; set; }

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
                },
                new() {
                        Id = 4,
                        CategoryName = "Work",
                        Color = "#1416df"
                },
                new() {
                        Id = 5,
                        CategoryName = "Personal",
                        Color = "#df1414"
                }
            };

            Mytasks = new ObservableCollection<MyTask>()
            {
                new() {
                        TaskName = "Learn .NET MAUI",
                        Completed = false,
                        CategoryId = 1,
                        TaskColor = "#CF14DF"
                },
                new() {
                        TaskName = "Build a sample app",
                        Completed = false,
                        CategoryId = 1,
                        TaskColor = "#CF14DF"
                },
                new() {
                        TaskName = "Read MAUI documentation",
                        Completed = true,
                        CategoryId = 1,
                        TaskColor = "#CF14DF"
                },
                new() {
                        TaskName = "Watch tutorial videos",
                        Completed = false,
                        CategoryId = 2,
                        TaskColor = "#df6f14"
                },
                new() {
                        TaskName = "Write blog post",
                        Completed = true,
                        CategoryId = 2,
                        TaskColor = "#df6f14"
                },
                new() {
                        TaskName = "Buy groceries",
                        Completed = true,
                        CategoryId = 3,
                        TaskColor = "#14df80"
                },
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach(var c in Categories)
            {
                IEnumerable<MyTask> tasks = from t in Mytasks
                            where t.CategoryId == c.Id
                            select t;

                IEnumerable<object> completed = from t in tasks
                                                where t.Completed == true
                                                select t;

                IEnumerable<MyTask> notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;

                c.PendingTasks = notCompleted.Count();
                c.Prcentage = (float)completed.Count() / (float)tasks.Count();
            }

            foreach (var t in Mytasks)
            {
                var catColor = (from c in Categories
                                where c.Id == t.CategoryId
                                select c.Color).FirstOrDefault();

                t.TaskColor = catColor!;
            }
        }
    }
}
