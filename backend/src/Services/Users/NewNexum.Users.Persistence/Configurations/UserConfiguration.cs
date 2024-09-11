using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Users.Domain.User;
using NewNexum.Users.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Users.Persistence.Users.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.Users);

            builder.HasKey(t => t.Id);
            builder.Property(user => user.Email).HasMaxLength(300);
            builder.Property(user => user.FirstName).HasMaxLength(200);
            builder.Property(user => user.LastName).HasMaxLength(200);

            builder.HasIndex(user => user.IdentityId).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
