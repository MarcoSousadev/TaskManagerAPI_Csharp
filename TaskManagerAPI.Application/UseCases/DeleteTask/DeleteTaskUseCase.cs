using TaskManagerAPI.Communication.DataBase;

namespace TaskManagerAPI.Application.UseCases.DeleteTask
{
    public class DeleteTaskUseCase
    {

        public void Execute(string id)
        {
            var taskForDelete = TaskDataBase.Task.Find(x => x.Id == id);


            if (taskForDelete == null)
            {
                throw new Exception("Resource not found");
            }

            TaskDataBase.Task.Remove(taskForDelete);
        }

    }
}
