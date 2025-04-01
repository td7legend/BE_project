using Microsoft.EntityFrameworkCore;

namespace be_project.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<int>();

            modelBuilder.Entity<UserLocation>()
                .HasKey(ul => new { ul.UserId, ul.LocationId });

            modelBuilder.Entity<UserLocation>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLocations)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa UserLocation khi User bị xóa

            modelBuilder.Entity<UserLocation>()
                .HasOne(ul => ul.Location)
                .WithMany(l => l.UserLocations)
                .HasForeignKey(ul => ul.LocationId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa UserLocation khi Location bị xóa

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Region)
                .WithMany(r => r.Locations) // Thêm WithMany để xác định rõ mối quan hệ
                .HasForeignKey(l => l.RegionId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Location khi Region bị xóa

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Location)
                .WithMany(l => l.Devices) // Định nghĩa quan hệ
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Region)
                .WithMany(r => r.Devices) // Định nghĩa quan hệ
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Content)
                .WithMany(c => c.Devices) // Định nghĩa quan hệ
                .HasForeignKey(d => d.ContentId)
                .OnDelete(DeleteBehavior.SetNull); // Nếu Content bị xóa, không xóa Device mà chỉ đặt ContentId = null

            modelBuilder.Entity<Media>()
                .HasOne(m => m.Content)
                .WithMany(c => c.Media) // Định nghĩa quan hệ
                .HasForeignKey(m => m.ContentId)
                .OnDelete(DeleteBehavior.Cascade); // Nếu Content bị xóa, xóa luôn Media liên quan
        }

    }
}
