using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNexum.Users.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Users.Infrastructure.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(t => t.Id);
            builder.Property(user => user.Email).HasMaxLength(300);
            builder.Property(user => user.FirstName).HasMaxLength(200);
            builder.Property(user => user.LastName).HasMaxLength(200);
            
            builder.HasIndex(user => user.IdentityId).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
