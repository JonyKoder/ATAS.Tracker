using ATAS.Tracker.BL;
using ATAS.Tracker.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ATAS.Tracker.ViewModels;
public class TaskListViewModel : ViewModelBase, INotifyPropertyChanged
{
    private readonly ITaskService _taskService;

    public TaskListViewModel(ITaskService taskService)
    {
        _taskService = taskService;
        GetTasks();
    }

    private List<TaskModel> tasks;

    private void GetTasks() { 
       tasks = _taskService.GetTasks();
    }
    public List<TaskModel> Tasks
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
