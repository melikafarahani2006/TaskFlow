using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public Guid TaskListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
        public ICollection<Tag> Tags { get; set; } = [];
        // Navigation Property
        public TaskList? TaskList { get; set; }
    }
}
