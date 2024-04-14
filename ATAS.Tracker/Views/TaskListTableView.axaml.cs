using ATAS.Tracker.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ATAS.Tracker.Views;

public partial class TaskListTableView : ReactiveUserControl<TaskListViewModel>
{
    private TaskListViewModel _taskListViewModel;
    public TaskListTableView()
    {
        this.DataContext = _taskListViewModel;
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}