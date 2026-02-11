using System.ComponentModel.DataAnnotations;
using TaskManagerAPI.Communication.Enums;

namespace TaskManagerAPI.Communication.Requests
{
    public class RequestTaskJson
    {

        [MaxLength(100, ErrorMessage = "It`s allowed only 100 characters per name")]
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public TaskPriority Priority { get; set; }
        
        public DateTime DueDate { get; set; }

        public TaskStatusEnum Status { get; set; }
    }
}
