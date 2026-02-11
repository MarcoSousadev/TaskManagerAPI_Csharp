using TaskManagerAPI.Communication.DataBase;
using TaskManagerAPI.Communication.Responses;

namespace TaskManagerAPI.Application.UseCases.GetTaskById
{
    public class GetTaskByIdUseCase
    {
        public ResponseTaskJson execute(string id) 
        {
            var task = TaskDataBase.Task.Find(x => x.Id == id);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            return task;

        }
    }
}
