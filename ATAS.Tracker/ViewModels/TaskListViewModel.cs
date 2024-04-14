using System;
using ATAS.Tracker.BL;
using ATAS.Tracker.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using DialogHostAvalonia;
using ReactiveUI;

namespace ATAS.Tracker.ViewModels;
public class TaskListViewModel : ViewModelBase, INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    public ReactiveCommand<int, Unit> EditTask { get; set; }
    public ReactiveCommand<int, Unit> DeleteTask { get; set; }
    public ICommand EditTaskCommand { get; private set; }

    public TaskListViewModel(ITaskService taskService)
    {
        _taskService = taskService;
        DeleteTask = ReactiveCommand.Create<int>(DeleteTaskFunc);
        EditTask = ReactiveCommand.Create<int>(EditTaskFunc);
        CreateTaskDialogViewModel.OnTaskCreated += CreateTaskDialogViewModelOnOnTaskCreated;
        EditTaskDialogViewModel.OnTaskEdited += EditTaskDialogViewModelOnOnTaskEdited;
        DeleteConfirmDialogViewModel.OnTaskDeleted += DeleteConfirmDialogViewModelOnOnTaskDeleted;
        GetTasks();
    }

    private void DeleteConfirmDialogViewModelOnOnTaskDeleted(object? sender, EventArgs e)
    {
        GetTasks();
        DialogHost.Close("ConfirmDeleteTaskDialog");
    }

    private void DeleteTaskFunc(int id)
    {
        var dialog = new DeleteConfirmDialogViewModel(_taskService, id);
        DialogHost.Show(dialog, "ConfirmDeleteTaskDialog");
    }

    private void EditTaskDialogViewModelOnOnTaskEdited(object? sender, EventArgs e)
    {
        GetTasks();
    }

    private void EditTaskFunc(int id)
    {
        var dialog = new EditTaskDialogViewModel(_taskService, id);
        DialogHost.Show(dialog, "EditTaskDialog");
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
