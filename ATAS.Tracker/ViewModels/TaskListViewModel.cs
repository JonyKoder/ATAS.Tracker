using System;
using ATAS.Tracker.BL;
using ATAS.Tracker.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;

namespace ATAS.Tracker.ViewModels;
public class TaskListViewModel : ViewModelBase, INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    public ReactiveCommand<int, Unit> EditTask { get; set; }
    public ICommand EditTaskCommand { get; private set; }

    public TaskListViewModel(ITaskService taskService)
    {
        _taskService = taskService;

        EditTask = ReactiveCommand.Create<int>(EditTaskFunc);
        CreateTaskDialogViewModel.OnTaskCreated += CreateTaskDialogViewModelOnOnTaskCreated;
        GetTasks();
    }

    private void EditTaskFunc(int id)
    {
        throw new NotImplementedException();
    }

    private void CreateTaskDialogViewModelOnOnTaskCreated(object? sender, EventArgs e)
    {
        GetTasks();
    }

    private List<TaskModel> tasks;

    private void GetTasks() { 
       tasks = _taskService.GetTasks();
       OnPropertyChanged(nameof(Tasks));

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
