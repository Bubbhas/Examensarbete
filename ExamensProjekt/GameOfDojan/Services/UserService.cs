using GameOfDojan.Models;
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
        private readonly RoleManager<ApplicationUser> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

    }
}
