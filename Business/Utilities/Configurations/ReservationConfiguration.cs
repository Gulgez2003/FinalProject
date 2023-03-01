namespace Business.Utilities.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.FullName).IsRequired().HasMaxLength(128).HasColumnType(SqlDbType.NVarChar.ToString());
            builder.Property(r => r.Email).IsRequired().HasMaxLength(50);
            builder.Property(r => r.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(r => r.ArrivalDateTime).IsRequired().HasMaxLength(50);
            builder.Property(r => r.DepartureDateTime).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Room).IsRequired().HasMaxLength(30);
            builder.Property(r => r.NumberOfAdults).IsRequired().HasMaxLength(6);
        }
    }
}