namespace Business.Utilities.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(128).HasColumnType(SqlDbType.NVarChar.ToString());
            builder.Property(s => s.Description).IsRequired().HasMaxLength(256);
            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
            builder.Property(s => s.Icon).IsRequired();
        }
    }
}