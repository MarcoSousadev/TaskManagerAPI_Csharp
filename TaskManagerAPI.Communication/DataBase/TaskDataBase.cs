using TaskManagerAPI.Communication.Responses;

namespace TaskManagerAPI.Communication.DataBase
{
    public class TaskDataBase
    {
         public static List<ResponseTaskJson> Task { get; set; } = new List<ResponseTaskJson>();
    }
}
