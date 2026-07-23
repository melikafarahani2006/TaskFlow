using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Application.Projects.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
