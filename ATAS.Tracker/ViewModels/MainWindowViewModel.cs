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

        public MainWindowViewModel(TaskListViewModel taskListViewModel)
        {
            TaskListViewModel = taskListViewModel;
            OpenTaskDialogCommand = ReactiveCommand.Create(() =>
            {
                var dialog = new CreateTaskViewDialogViewModel();
                DialogHost.Show(dialog, "CreateTaskDialog");
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

        public ICommand OpenTaskDialogCommand { get; }
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
