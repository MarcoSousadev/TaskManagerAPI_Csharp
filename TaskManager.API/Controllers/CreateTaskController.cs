using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.UseCases.CreateTask;
using TaskManagerAPI.Application.UseCases.DeleteTask;
using TaskManagerAPI.Application.UseCases.GetAllTask;
using TaskManagerAPI.Application.UseCases.GetTaskById;
using TaskManagerAPI.Application.UseCases.UpdateTaskById;
using TaskManagerAPI.Communication.Requests;
using TaskManagerAPI.Communication.Responses;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTaskController : ControllerBase
    {
       

        [HttpPost]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]

        public IActionResult CreateTask(RequestTaskJson request)
        {
            try
            {
                var useCase = new CreateTaskUseCase();
                var response = useCase.execute(request);
                return Created();
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
          
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseTaskJson>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        public IActionResult getAllTasks()
        {
            try 
            {
                var useCase = new GetAllTaskUseCase();

                var response = useCase.execute();

                return Ok(response);
            }

            catch (Exception e) 
            {
                return NotFound(e.Message);
            
            }

           
            

            
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult GetTaskById([FromRoute] string id)
        {
           var useCase = new GetTaskByIdUseCase();

           var response = useCase.execute(id);

           if(response == null)
            {
                return NotFound();
                
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]


        public IActionResult UpdateTaskById([FromRoute] string id, [FromBody] RequestTaskJson request)
        {
            var useCase = new UpdateTaskByIdUseCase();

            if(id == null) 
            {

                return BadRequest();
            }

            useCase.Execute(id, request);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteById([FromRoute] string id)
        {

            var useCase = new DeleteTaskUseCase();

            if(id == null) { return BadRequest(); }

            useCase.Execute(id);

            return Ok();
        }
    }


}
