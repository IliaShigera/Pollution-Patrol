namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.EntityTypeConfiguration;

internal sealed class RegistrationEntityTypeConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("Registrations");

        builder.OwnsOne(reg => reg.Status, statusBuilder =>
        {
            statusBuilder.Property(st => st.Value)
                .HasColumnName("Status")
                .IsRequired()
                .HasComment("The current status of the registration (e.g., pending, verified, expired)");
        });

        builder.HasIndex(reg => reg.VerificationCode).IsUnique();
        
        builder.Property(reg => reg.Username)
            .IsRequired()
            .HasComment("The user's name"); 
            
        builder.Property(reg => reg.Email)
            .IsRequired()
            .HasComment("The user's email address"); 

        builder.Property(reg => reg.PasswordHash)
            .IsRequired()
            .HasComment("The securely hashed password of the user"); 

        builder.Property(reg => reg.VerificationCode)
            .IsRequired()
            .HasComment("A unique code used for email verification purposes"); 

        builder.Property(reg => reg.RegisteredOn)
            .IsRequired()
            .HasComment("The date and time the user registered"); 

        builder.Property(reg => reg.ExpiresOn)
            .IsRequired()
            .HasComment("The date and time the registration or verification code will expire"); 

        builder.Ignore(reg => reg.DomainEvents);
    }
}