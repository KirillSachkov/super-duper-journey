using LearningPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistence.Configurations;

public partial class RoleConfiguration : IEntityTypeConfiguration<Core.Entities.Role>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity<RolePermission>(
                l => l.HasOne<Core.Entities.Permission>().WithMany().HasForeignKey(e => e.PermissionId),
                r => r.HasOne<Core.Entities.Role>().WithMany().HasForeignKey(e => e.RoleId));

        var roles = Enum
            .GetValues<Core.Enums.Role>()
            .Select(r => new Core.Entities.Role((int)r)
            {
                Id = (int)r,
                Name = r.ToString()
            });

        builder.HasData(roles);
    }
}
