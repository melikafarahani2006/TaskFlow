using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Application.TaskLists.Dtos
{
    public class CreateTaskListRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
