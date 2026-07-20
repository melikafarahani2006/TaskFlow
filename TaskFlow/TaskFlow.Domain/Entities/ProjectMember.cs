using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
