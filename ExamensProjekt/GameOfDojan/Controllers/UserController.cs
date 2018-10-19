using GameOfDojan.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly IUserData _userData;

        public UserController(UserService userService, IUserData userData)
        {
            _userService = userService;
            _userData = userData;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var newUser = await _userService.GetUser(userId);

            return View(newUser);
        }


    }
}
