using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Users.Domain.User;
using NewNexum.Users.Persistence.Constants;

namespace NewNexum.Users.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(TableNames.Permissions);

            builder.HasKey(permission => permission.Code);
            builder.Property(permission => permission.Code).HasMaxLength(100);

            builder.HasData(
                Permission.AddCertificationProfile,
                Permission.ModifyCertificationProfile,
                Permission.RemoveCertificationProfile);

            builder
                 .HasMany<Role>()
                 .WithMany()
                 .UsingEntity(joinBuilder =>
                 {
                     joinBuilder.ToTable(TableNames.RolePermission);

                     joinBuilder.HasData(
                         CreateRolePermission(Role.Member, Permission.AddCertificationProfile)
                       , CreateRolePermission(Role.Member, Permission.RemoveCertificationProfile)
                       , CreateRolePermission(Role.Member, Permission.ModifyCertificationProfile)
                    
                       , CreateRolePermission(Role.Admin, Permission.AddCertificationProfile)
                       , CreateRolePermission(Role.Admin, Permission.RemoveCertificationProfile)
                       , CreateRolePermission(Role.Admin, Permission.ModifyCertificationProfile));
                 });
        }

        private static object CreateRolePermission(Role role, Permission permission)
        {
            return new
            {
                RoleName = role.Name,
                PermissionCode = permission.Code,
            };
        }
    }
}
