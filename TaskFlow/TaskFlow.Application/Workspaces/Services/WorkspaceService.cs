using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Workspaces.Dtos;
using TaskFlow.Application.Workspaces.Interfaces;
using TaskFlow.Domain.Entities;


namespace TaskFlow.Application.Workspaces.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _repository;
        public WorkspaceService(IWorkspaceRepository repository)
        {
            _repository = repository;
        }
        public async Task<WorkspaceDto> CreateAsync(CreateWorkspaceRequest request)
        {
            if (await _repository.ExistsByNameAsync(request.Name))
            {
                throw new Exception("Workspace name already exists.");
            }

            var workspace = new Workspace
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(workspace);
            await _repository.SaveChangesAsync();

            return new WorkspaceDto
            {
                Id = workspace.Id,
                Name = workspace.Name
            };
        }
    }
}
