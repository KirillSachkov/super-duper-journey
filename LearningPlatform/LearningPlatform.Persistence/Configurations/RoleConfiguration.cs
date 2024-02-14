using LearningPlatform.Core.Enums;
using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistence.Configurations;

public partial class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(r => r.Role);

        builder.HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity<RolePermissionEntity>(
                l => l.HasOne<PermissionEntity>().WithMany().HasForeignKey(e => e.Permission),
                r => r.HasOne<RoleEntity>().WithMany().HasForeignKey(e => e.Role));

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles);

        var roles = Enum
            .GetValues<Role>()
            .Select(r => new RoleEntity
            {
                Role = r,
                Name = r.ToString()
            });

        builder.HasData(roles);
    }
}
