namespace be_project.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string HashPassword { get; set; }
        public bool Status { get; set; }
        public bool IsAndroid { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; } // Navigation property

        public int RegionId { get; set; }
        public Region Region { get; set; } // Navigation property

        public int? ContentId { get; set; } // Cho phép null nếu không có content
        public Content Content { get; set; } // Navigation property
    }

}
