using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class TaskList : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        // Navigation Properties
        public Project? Project { get; set; }
    }
}
