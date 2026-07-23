using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Application.Workspaces.Dtos
{
    public class WorkspaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
