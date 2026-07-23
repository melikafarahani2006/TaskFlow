using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Projects.Dtos;

namespace TaskFlow.Application.Projects.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateAsync(Guid workspaceId, CreateProjectRequest request);
    }
}
