using System;
using System.Reactive;
using ATAS.Tracker.BL;
using ReactiveUI;

namespace ATAS.Tracker.ViewModels;

public class DeleteConfirmDialogViewModel : ViewModelBase
{
    private readonly ITaskService _taskService;
    public static event EventHandler OnTaskDeleted;

    public ReactiveCommand<Unit, Unit> Confirm { get; set; } 
    public int Id { get; set; }
    public DeleteConfirmDialogViewModel(ITaskService taskService, int taskId)
    {
        _taskService = taskService;
        Id = taskId;
        Confirm = ReactiveCommand.Create(DeleteTask);
    }

    private void DeleteTask()
    {
       _taskService.DeleteTask(Id);
       OnTaskDeleted?.Invoke(this, EventArgs.Empty);
    }
}