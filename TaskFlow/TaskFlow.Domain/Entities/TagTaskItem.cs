using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class TagTaskItem : BaseEntity
    {
        public Guid TaskItemId { get; set; }
        public Guid TagId { get; set; }
        public TaskItem? TaskItem { get; set; } = null!;
        public Tag? Tag { get; set; } = null!;
    }
}
