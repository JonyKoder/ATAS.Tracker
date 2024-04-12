using ATAS.Tracker.BL;
using ATAS.Tracker.EF;
using ReactiveUI;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATAS.Tracker.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;
        public TaskListViewModel TaskListViewModel { get; set; }
        public MainWindowViewModel(ITaskService taskService, TaskListViewModel taskListViewModel)
        {
            _taskService = taskService;
            TaskListViewModel = taskListViewModel;
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

        public ICommand CreateTask { get; }
        public ICommand EditTask { get; }
        public ICommand DeleteTask { get; }

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
