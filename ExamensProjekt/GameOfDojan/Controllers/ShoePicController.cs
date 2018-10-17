using GameOfDojan.Data;
using GameOfDojan.Models;
using GameOfDojan.Services;
using GameOfDojan.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class ShoePicController : Controller
    {
        private readonly IShoePicService _shoePicService;
        private readonly IAiService _aiService;
        private readonly GameOfDojanDbContext _context;
        private readonly UserService _userService;

        public ShoePicController(IShoePicService shoePicService, IAiService aiService, GameOfDojanDbContext context, UserService userService)
        {
            _shoePicService = shoePicService;
            _aiService = aiService;
            _context = context;
            _userService = userService;
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

            var PredictionAnswer = await _aiService.MakePredictionRequest(filePath);
            UploadPicToDataBase(PredictionAnswer, filePath);
            return View("AiResponse", PredictionAnswer);
        }

        private async void UploadPicToDataBase(Rootobject predictionAnswer, string filePath)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            foreach (var item in predictionAnswer.Predictions)
            {
                if(item.TagName == "konsultdojan" && item.Probability > 0.7 && item.Probability < 1)
                {
                    _context.Add(new ShoePic
                    {
                        Probability = item.Probability,
                        ImageSource = filePath,
                        ApplicationUser = await _userService.GetUser(userId),
                    });
                }
            }
        }
    }
}
