namespace StudentApi
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public DateOnly Date { get; set; }
        public bool IsCompleted { get; set; }  
    }
}
