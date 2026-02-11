using TaskManagerAPI.Communication.DataBase;
using TaskManagerAPI.Communication.Responses;

namespace TaskManagerAPI.Application.UseCases.GetAllTask
{
    public class GetAllTaskUseCase
    {
      public List<ResponseTaskJson> execute()
    {
      return TaskDataBase.Task;
    }

    }
}