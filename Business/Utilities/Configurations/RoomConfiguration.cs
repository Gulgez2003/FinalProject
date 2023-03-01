namespace Business.Utilities.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.Title).IsRequired().HasMaxLength(128).HasColumnType(SqlDbType.NVarChar.ToString());
            builder.Property(r => r.Description).IsRequired().HasMaxLength(256);
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
            builder.Property(r => r.IsAvailable).HasDefaultValue(true);
            builder.Property(r => r.Services).IsRequired().HasMaxLength(256);
            builder.Property(r => r.BedType).IsRequired().HasMaxLength(128);
            builder.Property(r => r.Size).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Capacity).IsRequired().HasMaxLength(5);
            builder.Property(r => r.Price).IsRequired();
            builder.Property(r => r.ImageName).IsRequired();
        }
    }
}
