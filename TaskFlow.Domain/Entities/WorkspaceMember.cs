using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class WorkspaceMember : BaseEntity
    {
        public Guid WorkspaceId { get; set; }
        public Guid UserId { get; set; }
        public Workspace? Workspace { get; set; }
        public ApplicationUser? User { get; set; }
        public WorkspaceRole Role { get; set; } = WorkspaceRole.Member;
    }
}
