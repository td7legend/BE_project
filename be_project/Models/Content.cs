namespace be_project.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isVertical { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Media> Media { get; set; } // Thêm navigation property
        public List<Device> Devices { get; set; }
    }
}
