using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Workspaces.Dtos;

namespace TaskFlow.Application.Workspaces.Interfaces
{
    public interface IWorkspaceService
    {
        Task<WorkspaceDto> CreateAsync(CreateWorkspaceRequest request);
    }
}
