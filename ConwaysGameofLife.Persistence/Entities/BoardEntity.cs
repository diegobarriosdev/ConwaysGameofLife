namespace ConwaysGameofLife.Persistence.Entities
{
    public class BoardEntity
    {
        public int Id { get; set; }
        public string? Board {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

