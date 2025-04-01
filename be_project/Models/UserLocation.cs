namespace be_project.Models
{
    public class UserLocation
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
