using System;
using System.Reactive;
using ATAS.Tracker.BL;
using ATAS.Tracker.Dtos;
using ReactiveUI;

namespace ATAS.Tracker.ViewModels;

public class EditTaskDialogViewModel : ViewModelBase
{
    private readonly ITaskService _taskService;
            private string _title;
            public static event EventHandler OnTaskEdited;
    
    
            public EditTaskDialogViewModel(ITaskService taskService, int taskId)
            {
                _taskService = taskService;
                Id = taskId;
                GetTask(taskId);
                SaveCommand = ReactiveCommand.Create<int>(EditTask);
            }

            private void GetTask(int taskId)
            {
                 var task = _taskService.GetTask(taskId);
                 Title = task.Title;
                 Description = task.Description;
            }

            private void EditTask(int id)
            {
                _taskService.UpdateTask(id ,new TaskModelDto
                {
                    Description = this.Description,
                    CreatedDate = DateTime.Now,
                    Status = "new",
                    Title = this.Title,
                    CompletionDate = DateTime.Now.AddHours(2)
                });
                OnTaskEdited?.Invoke(this, EventArgs.Empty);
            }
            public ReactiveCommand<int, Unit> SaveCommand { get; }
    
            public string Title
            {
                get => _title;
                set => _title = value;
            }
    
            private string _description;
            public string Description
            {
                get => _description;
                set => _description = value;
            }
            private int _id;
            public int Id
            {
                get => _id;
                set => _id = value;
            }
            private DateTime _createdDate;
            public DateTime CreatedDate
            {
                get => _createdDate;
                set => _createdDate = value;
            }
    
            private DateTime _completionDate;
            public DateTime CompletionDate
            {
                get => _completionDate;
                set => _completionDate = value;
            }
    
            private string _status;
            public string Status
            {
                get => _status;
                set => _status = value;
            }
        }
