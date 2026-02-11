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

            try 
            {
                var useCase = new GetTaskByIdUseCase();

                var response = useCase.execute(id);

                return Ok(response);

            }

            catch (Exception e) 
            {
                return NotFound(e.Message);
            
            }

          
           

          
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]


        public IActionResult UpdateTaskById([FromRoute] string id, [FromBody] RequestTaskJson request)
        {

            try 
            {
                var useCase = new UpdateTaskByIdUseCase();

                useCase.Execute(id, request);

                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);

            }   
           
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteById([FromRoute] string id)
        {

            try 
            {
                var useCase = new DeleteTaskUseCase();
                useCase.Execute(id);
                return Ok();
            }

            catch (Exception e) {
                return BadRequest(e.Message);
            }

            
        }
    }


}
