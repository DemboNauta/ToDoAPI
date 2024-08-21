namespace ToDoAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AssignedUserId { get; set; }
        public int ProjectId { get; set; }


    }
}
