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
            var taskModel = new TaskModel() { 
              CompletionDate = dto.CompletionDate,
              CreatedDate = dto.CreatedDate,
              Description = dto.Description,
              Status = dto.Status,
              Title = dto.Title
            };
            _taskRepository.CreateTask(taskModel);
        }

        public List<TaskModel> GetTasks()
        {
            var tasks = _taskRepository.GetList();
            return tasks;
        }
    }
}
