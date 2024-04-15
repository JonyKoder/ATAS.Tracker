using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Tracker.Dtos
{
    public class TaskModelDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
    }
}
