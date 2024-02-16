using LearningPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission = LearningPlatform.Core.Enums.Permission;
using Role = LearningPlatform.Core.Enums.Role;

namespace LearningPlatform.Persistence.Configurations;

public partial class RolePermissionConfiguration
    : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        builder.HasKey(r => new { r.RoleId, r.PermissionId });

        builder.HasData(Create(Role.Author, Permission.Author),
                        Create(Role.Student, Permission.Student));
    }

    private static RolePermission Create(Role role, Permission permission)
        => new()
        {
            RoleId = (int)role,
            PermissionId = (int)permission
        };
}
