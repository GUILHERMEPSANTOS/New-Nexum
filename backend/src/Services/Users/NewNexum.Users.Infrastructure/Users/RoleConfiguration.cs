using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Users.Domain.User;

namespace NewNexum.Users.Infrastructure.Users
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(role => role.Name);
            builder.Property(role => role.Name).HasMaxLength(50);
            builder.
                HasMany<User>()
                .WithMany(user => user.Roles)
                .UsingEntity(joinEntityName =>
                {
                    joinEntityName.ToTable("user_roles");

                    joinEntityName
                        .Property("RoleName")
                        .HasColumnName("role_name");
                });
        }
    }
}
