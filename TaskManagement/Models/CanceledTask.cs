using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class CanceledTask
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CancelTime { get; set; }

        public String Content { get; set; }
    }
}
