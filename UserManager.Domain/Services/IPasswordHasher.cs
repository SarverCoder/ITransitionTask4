﻿namespace UserManager.Domain.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string password, string hash);
}