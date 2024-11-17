namespace Ordering.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(customerId => customerId.Value, dbid => CustomerId.Of(dbid));
        builder.Property(c => c.Name).HasMaxLength(255);
        builder.HasIndex(c => c.Email).IsUnique();
    }
}
