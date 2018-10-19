﻿using GameOfDojan.Models;

namespace GameOfDojan.Services
{
    public interface IUserData
    {
        void AddPointToUser(ApplicationUser newUser);
        ApplicationUser GetUser(string id);
    }
}