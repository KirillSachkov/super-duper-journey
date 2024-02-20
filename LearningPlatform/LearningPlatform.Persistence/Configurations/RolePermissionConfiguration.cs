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

        builder.HasData(Create(Role.Author, Permission.CreateCourse),
                        Create(Role.Author, Permission.CreateLesson),
                        Create(Role.Author, Permission.CreateComment),

                        Create(Role.Author, Permission.UpdateCourse),
                        Create(Role.Author, Permission.UpdateLesson),
                        Create(Role.Author, Permission.UpdateComment),

                        Create(Role.Author, Permission.DeleteCourse),
                        Create(Role.Author, Permission.DeleteLesson),
                        Create(Role.Author, Permission.DeleteComment),

                        Create(Role.Author, Permission.ReadCourse),
                        Create(Role.Author, Permission.ReadLesson),
                        Create(Role.Author, Permission.ReadComment),

                        Create(Role.Student, Permission.ReadCourse),
                        Create(Role.Student, Permission.ReadLesson),
                        Create(Role.Student, Permission.ReadComment));
    }

    private static RolePermission Create(Role role, Permission permission)
        => new()
        {
            RoleId = (int)role,
            PermissionId = (int)permission
        };
}
