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
        public async Task<IActionResult> UploadPic(List<IFormFile> files)
        {
            var filePath = "";
            try
            {
                filePath = await _shoePicService.AddPicToFolder(files);
            }
            catch(Exception e)
            {
                return BadRequest("Filerna måste vara jpg eller png" + e.Message);
            }

            return Ok(filePath);
        }
    }
}
