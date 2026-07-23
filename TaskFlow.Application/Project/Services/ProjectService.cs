using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Common;
using TaskFlow.Application.Projects.Dtos;
using TaskFlow.Application.Projects.Interfaces;
using TaskFlow.Application.Workspaces.Interfaces;
using TaskFlow.Domain.Entities;


namespace TaskFlow.Application.Projects.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IWorkspaceRepository _workspaceRepository;
        public ProjectService(IProjectRepository projectRepository, IWorkspaceRepository workspaceRepository)
        {
            _projectRepository = projectRepository;
            _workspaceRepository = workspaceRepository;
        }
        public async Task<ProjectDto> CreateAsync(Guid workspaceId, CreateProjectRequest request)
        {
            var workspace = await _workspaceRepository.GetByIdAsync(workspaceId);

            if (workspace is null)
            {
                throw new NotFoundException("Workspace not found.");
            }

            if (await _projectRepository.ExistsByNameAsync(request.Name))
            {
                throw new Exception("Project name already exists.");
            }

            var Project = new Project
            {
                WorkspaceId = workspaceId,
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _projectRepository.AddAsync(Project);
            await _projectRepository.SaveChangesAsync();

            return new ProjectDto
            {
                Id = Project.Id,
                Name = Project.Name,
                Description = request.Description
            };
        }
    }
}
