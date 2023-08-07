using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.EFCore.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new UserRole
                {
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                },
                new UserRole
                {
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new UserRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}