namespace be_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bu { get; set; }
        public Role Role { get; set; }
        public List<UserLocation> UserLocations { get; set; }
        public int RegionId { get; set; }

        public string Phone { get; set; }
        public string? GoogleID { get; set; }
        public Region Region { get; set; }
    }
    public enum Role
    {
        LocationAdmin,
        SystemAdmin
    }
}
