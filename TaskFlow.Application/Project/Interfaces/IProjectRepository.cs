using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Projects.Interfaces
{
    public interface IProjectRepository
    {
        Task AddAsync(Project Project);
        Task<Project?> GetByIdAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
