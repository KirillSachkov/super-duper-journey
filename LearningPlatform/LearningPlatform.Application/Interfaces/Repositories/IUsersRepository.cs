﻿using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Interfaces.Repositories;
public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByEmail(string email);
    Task<HashSet<Core.Enums.Permission>> GetUserPermissions(Guid userId);
}