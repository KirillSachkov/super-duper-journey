using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission = LearningPlatform.Core.Enums.Permission;
using Role = LearningPlatform.Core.Enums.Role;

namespace LearningPlatform.Persistence.Configurations;

public partial class RolePermissionConfiguration
    : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.Role, r.Permission});

        builder.HasData(Create(Role.Admin, Permission.Create),
                        Create(Role.Admin, Permission.Read),
                        Create(Role.Admin, Permission.Update),
                        Create(Role.Admin, Permission.Delete),
                        Create(Role.User, Permission.Read));
    }

    private static RolePermissionEntity Create(Role role, Permission permission)
        => new()
        {
            Role = role,
            Permission = permission
        };
}