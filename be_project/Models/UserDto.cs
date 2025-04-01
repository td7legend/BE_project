namespace be_project.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bu { get; set; }
        public Role Role { get; set; }
        public int RegionId { get; set; }
        public List<UserLocationDto> UserLocations { get; set; } 
    }

        public class UserLocationDto
    {
        public int LocationId { get; set; }
        public string Location { get; set; }
    }
}
