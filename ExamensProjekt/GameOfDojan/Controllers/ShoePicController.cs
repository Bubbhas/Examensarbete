using GameOfDojan.Data;
using GameOfDojan.Models;
using GameOfDojan.Services;
using GameOfDojan.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserService _userService;
        private readonly IShoePicData _shoePicData;

        public ShoePicController(IShoePicService shoePicService, IAiService aiService, UserService userService, IShoePicData shoePicData)
        {
            _shoePicService = shoePicService;
            _aiService = aiService;
            _userService = userService;
            _shoePicData = shoePicData;
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
            await UploadPicToDataBase(PredictionAnswer, filePath);
            return View("AiResponse", PredictionAnswer);
        }

        private async Task UploadPicToDataBase(Rootobject predictionAnswer, string filePath)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var newUser = await _userService.GetUser(userId);

            foreach (var item in predictionAnswer.Predictions)
            {
                if(item.TagName == "konsultdoja" && item.Probability > 0.7 && item.Probability < 1)
                {
                    _shoePicData.AddPictureToDatabase(new ShoePic
                    {
                        ImageSource = filePath,
                        ApplicationUser = newUser,
                        Probability = item.Probability
                    });

                    _shoePicData.AddPointToUser(newUser);
                }
            }
        }
    }
}
