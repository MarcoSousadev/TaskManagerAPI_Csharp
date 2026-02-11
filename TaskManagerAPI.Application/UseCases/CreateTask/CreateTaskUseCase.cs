using TaskManagerAPI.Communication.DataBase;
using TaskManagerAPI.Communication.Requests;
using TaskManagerAPI.Communication.Responses;

namespace TaskManagerAPI.Application.UseCases.CreateTask
{
    public class CreateTaskUseCase
    {
        public ResponseTaskJson execute(RequestTaskJson request)

        {
            
                var newTask = new ResponseTaskJson
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    DueDate = request.DueDate > DateTime.Today ? request.DueDate : throw new Exception("Not allowed past Date") ,
                    Priority = request.Priority,
                    Status = request.Status,
                };

                TaskDataBase.Task.Add(newTask);

                return newTask;

             
        }

    }
}