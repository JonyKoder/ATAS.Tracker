using ATAS.Tracker.Dtos;
using ATAS.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker.BL
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        void CreateTask(TaskModelDto dto);
        TaskModelDto GetTask(int taskId);
        void UpdateTask(int taskId, TaskModelDto dto);

        void DeleteTask(int taskId);
        
    }
}
