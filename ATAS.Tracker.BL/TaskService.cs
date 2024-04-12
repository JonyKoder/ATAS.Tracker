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

        public List<TaskModel> GetTasks()
        {
            var tasks = _taskRepository.GetList();
            return tasks;
        }
    }
}
