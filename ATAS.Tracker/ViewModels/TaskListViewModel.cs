using ATAS.Tracker.Models;
using ATAS.Tracker.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ATAS.Tracker.ViewModels;
public class TaskListViewModel : ViewModelBase, INotifyPropertyChanged
{
    private ObservableCollection<TaskModel> tasks;
    public ObservableCollection<TaskModel> Tasks
    {
        get { return tasks; }
        set
        {
            tasks = value;
            OnPropertyChanged(nameof(Tasks));
        }
    }

    private TaskModel selectedTask;
    public TaskModel SelectedTask
    {
        get { return selectedTask; }
        set
        {
            selectedTask = value;
            OnPropertyChanged(nameof(SelectedTask));
        }
    }

    public TaskListViewModel()
    {   
        // Инициализация коллекции Tasks примерными данными
        Tasks = new ObservableCollection<TaskModel>
        {
            new TaskModel { Id = 1, Title = "Sample Task 1", Description = "Descridsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssption 1", CreatedDate = DateTime.Now, Status = "In Progress" },
            new TaskModel { Id = 2, Title = "Sample Task 2", Description = "Description 2", CreatedDate = DateTime.Now, Status = "Completed", CompletionDate = DateTime.Now },
            new TaskModel { Id = 3, Title = "Sample Task 1", Description = "Descridsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssption 1", CreatedDate = DateTime.Now, Status = "In Progress" },
            new TaskModel { Id = 4, Title = "Sample Task 2", Description = "Description 2", CreatedDate = DateTime.Now, Status = "Completed", CompletionDate = DateTime.Now }
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
