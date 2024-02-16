using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistence.Configurations;

public partial class PermissionConfiguration : IEntityTypeConfiguration<Core.Entities.Permission>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(p => p.Id);

        var permissions = Enum
            .GetValues<Core.Enums.Permission>()
            .Select(p => new Core.Entities.Permission((int)p)
            {
                Name = p.ToString()
            });

        builder.HasData(permissions);
    }
}
