namespace Business.Utilities.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(128).HasColumnType(SqlDbType.NVarChar.ToString());
            builder.Property(b => b.Description).IsRequired().HasMaxLength(256);
            builder.Property(b => b.IsDeleted).HasDefaultValue(false);
            builder.Property(b => b.DateTime).IsRequired().HasMaxLength(50);
        }
    }
}
