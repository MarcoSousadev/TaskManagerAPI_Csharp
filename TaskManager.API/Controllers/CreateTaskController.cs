using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.UseCases.CreateTask;
using TaskManagerAPI.Communication.Requests.Task;
using TaskManagerAPI.Communication.Responses.Task;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTaskController : ControllerBase
    {
       

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreatedTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public IActionResult CreateTask(RequestCreateTaskJson request)
        {
            var useCase = new CreateTaskUseCase();

            if (request == null)
            {

                return BadRequest();

            }

            var response = useCase.execute(request);

            return Ok(response);
        }
    }
}
