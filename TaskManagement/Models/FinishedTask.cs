using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class FinishedTask
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime FinishTime { get; set; }

        public String Content { get; set; }
    }
}
