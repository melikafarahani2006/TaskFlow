using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Application.Projects.Dtos
{
    public class CreateProjectRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
