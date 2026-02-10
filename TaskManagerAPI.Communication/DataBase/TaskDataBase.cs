using TaskManagerAPI.Communication.Responses.Task;

namespace TaskManagerAPI.Communication.DataBase
{
    public class TaskDataBase
    {
         public static List<ResponseCreatedTaskJson> Task { get; set; } = new List<ResponseCreatedTaskJson>();
    }
}
