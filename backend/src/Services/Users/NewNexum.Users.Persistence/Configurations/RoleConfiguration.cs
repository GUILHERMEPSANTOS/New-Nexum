using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Users.Domain.User;
using NewNexum.Users.Persistence.Constants;

namespace NewNexum.Users.Persistence.Users.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(TableNames.Roles);

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

            builder.HasData(Role.Member, Role.Admin);
        }
    }
}
