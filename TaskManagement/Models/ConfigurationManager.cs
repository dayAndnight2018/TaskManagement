using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class ConfigurationManager
    {
        private static volatile Configuration configuration = new Configuration();

        static ConfigurationManager()
        {
            if (File.Exists(@"..\..\conf.dat"))
                configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(@"..\..\conf.dat"));
            if (configuration == null)
            {
                configuration = new Configuration();
                configuration.FinishedTask = new List<FinishedTask>();
                configuration.TaskItem = new List<TaskItem>();
                configuration.CanceledTask = new List<CanceledTask>();
            }

        }


        public static FinishedTask GetFinishedTask(Guid guid)
        {
            return configuration.FinishedTask.FirstOrDefault(o => o.Id == guid);
        }

        public static CanceledTask GetCanceledTask(Guid guid)
        {
            return configuration.CanceledTask.FirstOrDefault(o => o.Id == guid);
        }

        public static TaskItem GetTaskItem(Guid guid)
        {
            return configuration.TaskItem.FirstOrDefault(o => o.Id == guid);
        }

        public static List<TaskItem> GetTaskItems()
        {
            return configuration.TaskItem.OrderBy(o => o.StartTime).ToList();
        }

        public static List<CanceledTask> GetCanceledTasks()
        {
            return configuration.CanceledTask.OrderByDescending(o => o.EndTime).ToList();
        }

        public static List<FinishedTask> GetFinishedTasks()
        {
            return configuration.FinishedTask.OrderByDescending(o => o.EndTime).ToList();
        }

        public static void AddFinishedTask(Guid guid)
        {
            var task = configuration.TaskItem.First(o => o.Id == guid);
            configuration.FinishedTask.Add(new FinishedTask
            {
                StartTime = task.StartTime,
                EndTime = task.EndTime,
                FinishTime = DateTime.Now,
                Content = task.Content,
                Id = task.Id
            });
            configuration.TaskItem.Remove(task);
        }

        public static void AddCanceledTask(Guid guid)
        {
            var task = configuration.TaskItem.First(o => o.Id == guid);
            configuration.CanceledTask.Add(new CanceledTask
            {
                StartTime = task.StartTime,
                EndTime = task.EndTime,
                CancelTime = DateTime.Now,
                Content = task.Content,
                Id = task.Id
            });
            configuration.TaskItem.Remove(task);
        }

        public static void AddTaskItem(TaskItem item)
        {
            var model = configuration.TaskItem.FirstOrDefault(o => o.Id == item.Id);
            if (model!=null)
            {
                model.Content = item.Content;
                model.EndTime = item.EndTime;
                model.StartTime = item.StartTime;
                model.Status = item.Status;
            }
            else
                configuration.TaskItem.Add(item);
        }

        public static void RemoveFinishedTask(Guid guid)
        {
            configuration.FinishedTask.RemoveAll(o => o.Id == guid);
        }

        public static void RemoveCanceledTask(Guid guid)
        {
            configuration.CanceledTask.RemoveAll(o => o.Id == guid);
        }

        public static void RemoveTaskItem(Guid guid)
        {
            configuration.TaskItem.RemoveAll(o => o.Id == guid);
        }

        public static void UpdateStatus(Guid guid, WpfControlLibrary.WPFControls.TaskStatus status)
        {
            var model = configuration.TaskItem.First(o => o.Id == guid);
            model.Status = status;
        }

        public static void SaveChanges()
        {
            if (!File.Exists(@"..\..\conf.dat"))
            {
                File.Create(@"..\..\conf.dat");
            }
            using (FileStream fs = new FileStream(@"..\..\conf.dat", FileMode.Create, FileAccess.Write))
            {
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(configuration));
                 fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}

