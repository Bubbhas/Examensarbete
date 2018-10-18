using GameOfDojan.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IUserData _userData;
        private readonly UserService _userService;

        public StatisticController(IUserData userData, UserService userService)
        {
            _userData = userData;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTopList()
        {
            return Ok(_userService.GetTop10UserPoints());
        }
    }
}

