using ATAS.Tracker.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DialogHostAvalonia;
using ReactiveUI;

namespace ATAS.Tracker.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif

        }
    }
}