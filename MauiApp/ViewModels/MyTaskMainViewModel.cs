using MauiApp.Models;
using System.Collections.ObjectModel;

namespace MauiApp.ViewModels
{
    public class MyTaskMainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<MyTask> Mytasks { get; set; } = new();

        public MyTaskMainViewModel()
        {
            FillData();
        }

        private void FillData()
        {
            Categories.Clear();
            Categories.Add(new Category
            {
                Id = 1,
                CategoryName = ".NET MAUI Course",
                Color = "#CF14DF"
            });
            Categories.Add(new Category
            {
                Id = 2,
                CategoryName = "Tutorials",
                Color = "#df6f14"
            });
            Categories.Add(new Category
            {
                Id = 3,
                CategoryName = "Shopping",
                Color = "#14df80"
            });
            Categories.Add(new Category
            {
                Id = 4,
                CategoryName = "Work",
                Color = "#1416df"
            });
            Categories.Add(new Category
            {
                Id = 5,
                CategoryName = "Personal",
                Color = "#df1414"
            });

            Mytasks.Clear();
            Mytasks.Add(new MyTask
            {
                TaskName = "Learn .NET MAUI",
                Completed = false,
                CategoryId = 1,
                TaskColor = "#CF14DF"
            });
            Mytasks.Add(new MyTask
            {
                TaskName = "Build a sample app",
                Completed = false,
                CategoryId = 1,
                TaskColor = "#CF14DF"
            });
            Mytasks.Add(new MyTask
            {
                TaskName = "Read MAUI documentation",
                Completed = true,
                CategoryId = 1,
                TaskColor = "#CF14DF"
            });
            Mytasks.Add(new MyTask
            {
                TaskName = "Watch tutorial videos",
                Completed = false,
                CategoryId = 2,
                TaskColor = "#df6f14"
            });
            Mytasks.Add(new MyTask
            {
                TaskName = "Write blog post",
                Completed = true,
                CategoryId = 2,
                TaskColor = "#df6f14"
            });
            Mytasks.Add(new MyTask
            {
                TaskName = "Buy groceries",
                Completed = true,
                CategoryId = 3,
                TaskColor = "#14df80"
            });

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
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
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
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
