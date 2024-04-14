using System.ComponentModel;
using System.Linq;
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
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public bool _isVisibleTable { get; set; } = false;
        public bool _isVisiblePanel { get; set; } = true;
        private string _description;

        public bool IsVisiblePanel
        {
            get => _isVisiblePanel;
            set
            {
                _isVisiblePanel = value;
                OnPropertyChanged(nameof(IsVisiblePanel));
            }
        }

        public bool IsVisibleTable
        {
            get => _isVisibleTable;
            set
            {
                _isVisibleTable = value;
                OnPropertyChanged(nameof(IsVisibleTable));
            }
        }

        public TaskListViewModel TaskListViewModel { get; set; }
        private readonly ITaskService _taskService;

        public MainWindowViewModel(TaskListViewModel taskListViewModel, ITaskService taskService)
        {
            _taskService = taskService;
            TaskListViewModel = taskListViewModel;
            ChangeView = ReactiveCommand.Create(() =>
            {
                IsVisiblePanel = !IsVisiblePanel;
                IsVisibleTable = !IsVisibleTable;
            });
            Sort = ReactiveCommand.Create<int>((index) => { SortFunc(index); });
            OpenTaskDialogCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var dialog = new CreateTaskDialogViewModel(taskService);
                await DialogHost.Show(dialog, "CreateTaskDialog");
            });


            EditTask = ReactiveCommand.Create(async () => { await EditTaskAsync(); });

            DeleteTask = ReactiveCommand.Create(async () => { await DeleteTaskAsync(); });
        }

        private void SortFunc(int filterNum)
        {
            switch (filterNum)
            {
                case 0:
                {
                    break;
                }
                case 1:
                {
                    TaskListViewModel.Tasks = _taskService.GetTasks().OrderBy(x => x.Title).ToList();
                    break;
                }
                case 2:
                {
                    TaskListViewModel.Tasks = _taskService.GetTasks().OrderBy(x => x.Description).ToList();
                    break;
                }
            }
        }

        public ReactiveCommand<Unit, Unit> OpenTaskDialogCommand { get; }
        public ReactiveCommand<int, Unit> Sort { get; set; }

        public ReactiveCommand<Unit, Unit> ChangeView { get; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}