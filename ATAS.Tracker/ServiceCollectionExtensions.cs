using ATAS.Tracker.BL;
using ATAS.Tracker.EF;
using ATAS.Tracker.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            collection.AddSingleton<ITaskService, TaskService>();
            collection.AddSingleton<ITaskRepository, TaskRepository>();
            collection.AddDbContext<AppDbContext>();
            collection.AddSingleton<MainWindowViewModel>();
            collection.AddSingleton<TaskListViewModel>();
        }
    }
}
