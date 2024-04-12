using ATAS.Tracker.BL;
using ATAS.Tracker.ViewModels;
using ATAS.Tracker.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ATAS.Tracker
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var collection = new ServiceCollection();
            collection.AddCommonServices();

            // Creates a ServiceProvider containing services from the provided IServiceCollection
            var services = collection.BuildServiceProvider();

            var service = services.GetRequiredService<ITaskService>();
            var vm = services.GetRequiredService<TaskListViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(service, vm),
                };

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}