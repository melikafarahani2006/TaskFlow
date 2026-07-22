using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Workspaces.Interfaces
{
    public interface IWorkspaceRepository
    {
        Task AddAsync(Workspace workspace);
        Task<Workspace?> GetByIdAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
