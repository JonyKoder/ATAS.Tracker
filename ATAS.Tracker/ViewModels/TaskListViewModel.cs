using ATAS.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker.ViewModels
{
    public class TaskListViewModel : ViewModelBase
    {
        public ObservableCollection<TaskModel> Tasks { get; set; }
        public TaskModel SelectedTask { get; set; }

        public TaskListViewModel()
        {
            // Initialize Tasks collection with sample data
            Tasks = new ObservableCollection<TaskModel>
            {
                new TaskModel { Id = 1, Title = "Sample Task 1", Description = "Description 1", CreatedDate = DateTime.Now, Status = "In Progress" },
                new TaskModel { Id = 2, Title = "Sample Task 2", Description = "Description 2", CreatedDate = DateTime.Now, Status = "Completed", CompletionDate = DateTime.Now }
            };
        }
    }
}
