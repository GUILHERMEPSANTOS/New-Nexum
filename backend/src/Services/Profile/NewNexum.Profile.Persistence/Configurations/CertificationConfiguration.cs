using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Core.ValueObjects;
using NewNexum.Profile.Domain;
using NewNexum.Profile.Persistence.Constants;

namespace NewNexum.Profile.Persistence.Configurations
{
    internal sealed class CertificationConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.OwnsOne(certification => certification.Url, urlBuilder =>
            {
                urlBuilder.Property(url => url.Value)
                   .HasColumnName("Url")
                   .HasColumnType("NVARCHAR(MAX)");
                urlBuilder.WithOwner();
            });


            builder.ToTable(TableNames.Certification);

            builder.HasKey(certification => certification.Id);


            builder
               .Property(c => c.UserId)
               .IsRequired();

            builder
               .Property(certification => certification.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(certification => certification.IssuingOrganization)
               .HasMaxLength(150)
               .IsRequired();

            builder
                .Property(certification => certification.DateOfIssue);

            builder
                .Property(certification => certification.ExpirationDate);

            builder
                .Property(certification => certification.CredentialCode);

            builder
                .Property(certification => certification.DateAdded);

            builder
                .Property(certification => certification.UpdateDate);
        }
    }
}
