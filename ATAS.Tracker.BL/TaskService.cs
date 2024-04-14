using ATAS.Tracker.Dtos;
using ATAS.Tracker.EF;
using ATAS.Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ATAS.Tracker.BL
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(TaskModelDto dto)
        {
            var taskModel = new TaskModel()
            {
                CompletionDate = dto.CompletionDate,
                CreatedDate = dto.CreatedDate,
                Description = dto.Description,
                Status = dto.Status,
                Title = dto.Title
            };
            _taskRepository.CreateTask(taskModel);
        }

        public TaskModelDto GetTask(int taskId)
        {
            var task = _taskRepository.GetTask(taskId);
            return new TaskModelDto()
            {
                Title = task.Title,
                CompletionDate = task.CompletionDate,
                Description = task.Description,
                Status = task.Status,
                CreatedDate = task.CreatedDate,
                Id = task.Id
            };
        }

        public void UpdateTask(int taskId, TaskModelDto dto)
        {
            var model = new TaskModel()
            {
              CompletionDate = dto.CompletionDate,
              Status = dto.Status,
              Description = dto.Description,
              CreatedDate = dto.CreatedDate,
              Title = dto.Title
            };
            _taskRepository.UpdateTask(taskId, model);
        }

        public void DeleteTask(int taskId)
        {
            _taskRepository.DeleteTask(taskId);
        }
        

        public List<TaskModel> GetTasks()
        {
            var tasks = _taskRepository.GetList();
            return tasks;
        }
    }
}