namespace Models.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
