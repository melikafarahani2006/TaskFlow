using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Common;
using TaskFlow.Application.Projects.Interfaces;
using TaskFlow.Application.TaskLists.Dtos;
using TaskFlow.Application.TaskLists.Interfaces;
using TaskFlow.Domain.Entities;


namespace TaskFlow.Application.TaskLists.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IProjectRepository _projectRepository;
        public TaskListService(ITaskListRepository projectRepository, IProjectRepository workspaceRepository)
        {
            _taskListRepository = projectRepository;
            _projectRepository = workspaceRepository;
        }
        public async Task<TaskListDto> CreateAsync(Guid projectId, CreateTaskListRequest request)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project is null)
            {
                throw new NotFoundException("Project not found.");
            }

            if (await _taskListRepository.ExistsByNameAsync(request.Name))
            {
                throw new Exception("TaskList name already exists.");
            }

            var nextOrder = await _taskListRepository.GetNextOrderAsync(projectId);

            var TaskList = new TaskList
            {
                ProjectId = projectId,
                Name = request.Name,
                Order = nextOrder + 1,
                CreatedAt = DateTime.UtcNow
            };

            await _taskListRepository.AddAsync(TaskList);
            await _taskListRepository.SaveChangesAsync();

            return new TaskListDto
            {
                Id = TaskList.Id,
                Name = TaskList.Name,
            };
        }
    }
}
