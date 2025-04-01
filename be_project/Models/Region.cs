namespace be_project.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
        public List<Device> Devices { get; set; }
    }
}
