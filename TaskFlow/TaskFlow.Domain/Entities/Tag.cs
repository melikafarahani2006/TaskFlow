using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        // Navigation Properties
        public Project? Project { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; } = [];
    }
}
