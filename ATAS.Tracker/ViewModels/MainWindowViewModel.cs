using ReactiveUI;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATAS.Tracker.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand CreateTask { get; }
        public ICommand EditTask { get; }
        public ICommand DeleteTask { get; }

        public TaskListViewModel TaskListViewModel { get; set; }

        public MainWindowViewModel()
        {
            TaskListViewModel = new TaskListViewModel();
            CreateTask =  ReactiveCommand.Create(async () =>
            {
                await CreateTaskAsync();
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

        private async Task CreateTaskAsync()
        {
            // Ваша логика для создания задачи
        }

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
