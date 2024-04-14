using System.Reactive;
using ATAS.Tracker.BL;
using ATAS.Tracker.EF;
using ATAS.Tracker.Views;
using DialogHostAvalonia;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATAS.Tracker.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TaskListViewModel TaskListViewModel { get; set; }

        public MainWindowViewModel(TaskListViewModel taskListViewModel, ITaskService taskService)
        {
            TaskListViewModel = taskListViewModel;
            
            OpenTaskDialogCommand = ReactiveCommand.CreateFromTask( async () =>
            {
                var dialog = new CreateTaskDialogViewModel(taskService);
                await DialogHost.Show(dialog, "CreateTaskDialog");
            });


            EditTask =  ReactiveCommand.Create(async () =>
            {
                await EditTaskAsync();
            });

            DeleteTask = ReactiveCommand.Create(async () =>
            {
                await DeleteTaskAsync();
            });
        }

        public ReactiveCommand<Unit, Unit> OpenTaskDialogCommand { get; }
        public ICommand EditTask { get; }
        public ICommand DeleteTask { get; }

        private async Task EditTaskAsync()
        {
            // Ваша логика для редактирования задачи
        }

        private async Task DeleteTaskAsync()
        {
            // Ваша логика для удаления задачи
        }
    }

}
