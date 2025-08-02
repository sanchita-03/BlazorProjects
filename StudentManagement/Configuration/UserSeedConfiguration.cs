using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagement.Configuration
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            builder.HasData
            (
                new IdentityUser
                {
                    Id = "41776062-6086-1fbf-b923-2879a6680b9a",

                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new IdentityUser
                {
                    Id = "41776062-6086-1fbf-b923-2879a6680b9b",
                    UserName = "mandhare@gmail.com",
                    NormalizedUserName = "MANDHARE@GMAIL.COM",
                    Email = "mandhare@gmail.com",
                    NormalizedEmail = "MANDHARE@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Sanchita@123")
                }
            );
        }
    }
}
