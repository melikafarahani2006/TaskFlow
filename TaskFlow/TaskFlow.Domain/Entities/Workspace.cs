using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Workspace : BaseEntity
    {
        public ICollection<Project> Projects { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<WorkspaceMember> Members { get; set; } = [];
    }
}
