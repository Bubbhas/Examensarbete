﻿using GameOfDojan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public IEnumerable<ApplicationUser> GetTop10UserPoints()
        {
            IEnumerable<ApplicationUser> listOfUsersNames = _userManager.Users.ToList();

            IEnumerable<ApplicationUser> topUsersPoints = listOfUsersNames.OrderBy(x => x.Points).Take(10);

            return  topUsersPoints;
        }

    }
}
