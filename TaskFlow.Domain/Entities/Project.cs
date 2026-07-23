using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Guid WorkspaceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<TaskList> TaskLists { get; set; } = [];
        public ICollection<Tag> Tags { get; set; } = [];
        public ICollection<ProjectMember> Members { get; set; } = [];

        // Navigation Property
        public Workspace? Workspace { get; set; }
    }
}
