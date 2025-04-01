namespace be_project.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public List<UserLocation> UserLocations { get; set; }
        public int RegionId { get; set; }
        public List<Device> Devices { get; set; }
    }
}

