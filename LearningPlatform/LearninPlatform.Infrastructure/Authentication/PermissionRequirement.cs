using LearningPlatform.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LearninPlatform.Infrastructure.Authentication;

public class PermissionRequirement(Permission[] permissions)
    : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}