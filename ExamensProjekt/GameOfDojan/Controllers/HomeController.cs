using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameOfDojan.Models;
using GameOfDojan.Services;

namespace GameOfDojan.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        private readonly IShoePicData _shoePicData;
        private readonly IUserData _userData;

        public HomeController(UserService userService, IShoePicData shoePicData, IUserData userData)
        {
            _userService = userService;
            _shoePicData = shoePicData;
            _userData = userData;
        }

        public IActionResult Index()
        {
            var vm = new HomePage
            {
                User = _userService.GetTop10UserPoints(),
                ShoePic = _shoePicData.GetAllShoePicsFromLast7Days()
            };

            return View(vm);
        }
        //public IActionResult GetTopList()
        //{
        //    return Ok(_userService.GetTop10UserPoints());
        //}
        //public async Task<IActionResult> GetAllPics()
        //{

        //    return Ok();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userData.GetAllUsers();

            return Ok(allUsers);

        }
    }
}
