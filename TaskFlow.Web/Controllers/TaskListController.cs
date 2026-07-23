using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.TaskLists.Dtos;
using TaskFlow.Application.TaskLists.Interfaces;

namespace TaskFlow.Web.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/TaskLists")]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _TaskListService;

        public TaskListController(ITaskListService TaskListService)
        {
            _TaskListService = TaskListService;
        }


        [HttpPost]
        public async Task<ActionResult<TaskListDto>> Create(Guid projectId, CreateTaskListRequest request)
        {
            var TaskList = await _TaskListService.CreateAsync(projectId, request);

            return Ok(TaskList);
        }
    }
}
