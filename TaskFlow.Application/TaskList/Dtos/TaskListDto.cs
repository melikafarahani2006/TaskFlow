using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Application.TaskLists.Dtos
{
    public class TaskListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
