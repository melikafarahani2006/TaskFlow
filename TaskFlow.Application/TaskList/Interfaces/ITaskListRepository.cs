using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.TaskLists.Interfaces
{
    public interface ITaskListRepository
    {
        Task AddAsync(TaskList TaskList);
        Task<TaskList?> GetByIdAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
        Task<int> GetNextOrderAsync(Guid projectId);
        Task SaveChangesAsync();
    }
}
