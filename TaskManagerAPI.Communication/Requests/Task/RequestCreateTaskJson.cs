using TaskManagerAPI.Communication.Enums;

namespace TaskManagerAPI.Communication.Requests.Task
{
    public class RequestCreateTaskJson
    {

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public TaskPriority Priority { get; set; }
        
        public DateTime DueDate { get; set; }

        public string Status { get; set; }
    }
}
