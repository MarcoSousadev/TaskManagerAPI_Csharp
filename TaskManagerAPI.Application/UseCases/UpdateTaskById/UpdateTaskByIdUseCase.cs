
using TaskManagerAPI.Communication.DataBase;
using TaskManagerAPI.Communication.Requests;

namespace TaskManagerAPI.Application.UseCases.UpdateTaskById
{
    public class UpdateTaskByIdUseCase { 
   
        public void Execute(string id, RequestTaskJson request)
    {
        var task = TaskDataBase.Task.Find(x => x.Id == id);

            if(task == null)
            {
                throw new Exception("Resource not found. ");
            }

            task.Name = request.Name;
            task.Status = request.Status;
            task.DueDate = request.DueDate;
            task.Description = request.Description;
            task.Priority = request.Priority;
            
        }
 }

}