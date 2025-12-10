using MauiApp.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace MauiApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MyTaskMainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MyTaskMainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
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

            Tasks = new ObservableCollection<MyTask>
               {
                    new() {
                         TaskName = "Upload exercise files",
                         Completed = false,
                         CategoryId = 1
                    },
                    new() {
                         TaskName = "Plan next course",
                         Completed = false,
                         CategoryId = 1
                    },
                    new() {
                         TaskName = "Upload new ASP.NET video on YouTube",
                         Completed = false,
                         CategoryId = 2
                    },
                    new() {
                         TaskName = "Fix Settings.cs class of the project",
                         Completed = false,
                         CategoryId = 2
                    },
                    new() {
                         TaskName = "Update github repository",
                         Completed = true,
                         CategoryId = 2
                    },
                    new() {
                         TaskName = "Buy eggs",
                         Completed = false,
                         CategoryId = 3
                    },
                    new() {
                         TaskName = "Go for the pepperoni pizza",
                         Completed = false,
                         CategoryId = 3
                    },
               };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
