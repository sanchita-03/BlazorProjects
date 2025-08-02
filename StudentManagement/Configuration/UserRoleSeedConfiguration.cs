using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagement.Configuration
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "41776062-6086-1fbf-b923-2879a6680b9a",
                    RoleId = "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d"
                },
                new IdentityUserRole<string>
                {
                    UserId = "41776062-6086-1fbf-b923-2879a6680b9b",
                    RoleId = "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e"
                }
             );
        }
    }
}
