using ATAS.Tracker.EF;
using ATAS.Tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker.BL
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            using (var context = new AppDbContext())
            {
                for (int i = 1; i <= 5; i++)
                {
                    TaskModel task = new TaskModel
                    {
                        Id = i,
                        Title = $"Task {i}",
                        Description = $"Description for Task {i}",
                        CreatedDate = DateTime.Now,
                        CompletionDate = DateTime.Now.AddDays(7), // Пример установки завтрашней даты
                        Status = "Pending"
                    };

                    context.Tasks.Add(task);
                }

                context.SaveChanges();
            }

        }
/// <summary>
/// Что то делает 
/// </summary>
/// <param name="taskModel"></param>
/// <returns></returns>
        public TaskModel CreateTask(TaskModel taskModel)
        {
            _dbContext.Tasks.Add(taskModel);
            _dbContext.SaveChanges();
            return taskModel;
               
        }

        public void UpdateTask(int taskId, TaskModel model)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == taskId);
            task.Description = model.Description;
            task.Status = "new";
            task.Title = model.Title;
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == taskId);
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public TaskModel GetTask(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            return task;
        }

        public  List<TaskModel> GetList()
        {
            var tasks =  _dbContext.Tasks.ToList();

            return tasks;
        }
    }
}
