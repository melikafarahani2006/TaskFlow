using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.TaskLists.Dtos;

namespace TaskFlow.Application.TaskLists.Interfaces
{
    public interface ITaskListService
    {
        Task<TaskListDto> CreateAsync(Guid projectId, CreateTaskListRequest request);
    }
}
