using ATAS.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker.BL
{
    public interface ITaskRepository
    {
        List<TaskModel> GetList();
        TaskModel CreateTask(TaskModel taskModel);
        void UpdateTask(int taskId, TaskModel model);

        void DeleteTask(int taskId);
        TaskModel GetTask(int id);
    }
}
