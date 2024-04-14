using ATAS.Tracker.Dtos;
using ATAS.Tracker.Models;
using ATAS.Tracker.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ATAS.Tracker.Views;

public partial class DeleteConfirmDialogView : ReactiveUserControl<DeleteConfirmDialogViewModel>
{

    public DeleteConfirmDialogView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}