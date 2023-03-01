namespace DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Setting>? Settings { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
