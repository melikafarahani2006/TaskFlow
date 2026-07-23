using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Projects.Dtos;
using TaskFlow.Application.Projects.Interfaces;

namespace TaskFlow.Web.Controllers
{
    [ApiController]
    [Route("api/worspaces/{workspaceId}/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _ProjectService;

        public ProjectController(IProjectService ProjectService)
        {
            _ProjectService = ProjectService;
        }


        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create(Guid workspaceId,CreateProjectRequest request)
        {
            var Project = await _ProjectService.CreateAsync(workspaceId,request);

            return Ok(Project);
        }
    }
}
