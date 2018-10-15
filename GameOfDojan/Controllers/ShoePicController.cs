using GameOfDojan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class ShoePicController : Controller
    {
        private readonly IShoePicService _shoePicService;

        public ShoePicController(IShoePicService shoePicService)
        {
            _shoePicService = shoePicService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPic(List<IFormFile> files)
        {

            return Ok(_shoePicService.AddPicToFolder(files));
        }
    }
}
