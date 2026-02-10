using TaskManagerAPI.Communication.Enums;

namespace TaskManagerAPI.Communication.Responses.Task
{
    public class ResponseCreatedTaskJson
    {
        public string Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public TaskPriority Priority { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }
    }

}