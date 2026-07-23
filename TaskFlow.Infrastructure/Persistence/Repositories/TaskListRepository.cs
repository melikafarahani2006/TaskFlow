using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.TaskLists.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskList TaskList)
        {
            await _context.TaskLists.AddAsync(TaskList);
        }

        public async Task<TaskList?> GetByIdAsync(Guid id)
        {
            return await _context.TaskLists.FindAsync(id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.TaskLists.AnyAsync(x => x.Name == name);
        }

        public async Task<int> GetNextOrderAsync(Guid projectId)
        {
            return (await _context.TaskLists
                .Where(x => x.ProjectId == projectId)
                .MaxAsync(x => (int?)x.Order)) ?? 0;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
