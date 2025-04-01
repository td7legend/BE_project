namespace be_project.Models
{
    public class Media
    {
        public int Id { get; set; }
        public bool IsVideo { get; set; }
        public string Path { get; set; }
        public int DisplayDuration { get; set; }
        public int ContentId { get; set; }
        public Content Content { get; set; } 
        public int OrderIndex { get; set; }
    }

}
