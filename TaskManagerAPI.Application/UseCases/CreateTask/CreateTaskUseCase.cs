using TaskManagerAPI.Communication.DataBase;
using TaskManagerAPI.Communication.Requests.Task;
using TaskManagerAPI.Communication.Responses.Task;

namespace TaskManagerAPI.Application.UseCases.CreateTask
{
    public class CreateTaskUseCase
    {
        public ResponseCreatedTaskJson execute(RequestCreateTaskJson request)
        {

                var newTask = new ResponseCreatedTaskJson
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    Priority = request.Priority,
                    Status = request.Status,
                };

                TaskDataBase.Task.Add(newTask);

                return newTask;

             
        }

    }
}