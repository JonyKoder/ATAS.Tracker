using ATAS.Tracker.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ATAS.Tracker;

public partial class TaskListView : ReactiveUserControl<TaskListViewModel>
{
    public TaskListView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}