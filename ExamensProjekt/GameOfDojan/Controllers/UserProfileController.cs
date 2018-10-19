using GameOfDojan.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserData _userData;

        public UserProfileController(IUserData userData)
        {
            _userData = userData;
        }
        public IActionResult Index(string id)
        {
            var user = _userData.GetUser(id);

            return View(user);
        }

        public IActionResult GetUserByUserName(string userName)
        {
            var user = "";
            try
            {
                user = _userData.GetUserByUserName(userName).Id;
            }
            catch (Exception)
            {
                return View("UserNotFound");
            }

           return RedirectToAction("Index", "UserProfile", new { id = user });
        }

    }
}
