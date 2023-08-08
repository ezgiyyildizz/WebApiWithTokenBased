using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiWithTokenBased.EFCore.Config
{
    // Kullanıcı rolleri için örnek veri yapılandırması
    public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Kullanıcı rolleri için örnek veri ekleme işlemi
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
