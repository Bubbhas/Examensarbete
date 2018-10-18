﻿using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public class UserData : IUserData
    {
        private readonly GameOfDojanDbContext _context;

        public UserData(GameOfDojanDbContext context)
        {
            _context = context;
        }

        public void AddPointToUser(ApplicationUser User)
        {
            User.Points += 10;

            _context.SaveChanges();
        }

        public List<ApplicationUser> GetTop10UserPoints()
        {
            var listOfUsers = new List<ApplicationUser>();

            return listOfUsers;
        }

    }
}