using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Workspaces.Dtos;
using TaskFlow.Application.Workspaces.Interfaces;

namespace TaskFlow.Web.Controllers
{
    [ApiController]
    [Route("api/workspaces")]
    public class WorkspaceController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        public WorkspaceController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }


        [HttpPost]
        public async Task<ActionResult<WorkspaceDto>> Create(CreateWorkspaceRequest request)
        {
            var workspace = await _workspaceService.CreateAsync(request);

            return Ok(workspace);
        }
    }
}
