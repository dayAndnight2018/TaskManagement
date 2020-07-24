using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class Configuration
    {
        public List<FinishedTask> FinishedTask { get;set;}

        public List<CanceledTask> CanceledTask { get; set; }

        public List<TaskItem> TaskItem { get; set; }
    }
}
