using GameOfDojan.Models;
using GameOfDojan.Services;
using GameOfDojan.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class ShoePicController : Controller
    {
        private readonly IShoePicService _shoePicService;
        private readonly IAiService _aiService;
        private readonly UserService _userService;
        private readonly IShoePicData _shoePicData;
        private readonly IUserData _userData;
        private readonly ICommentData _commentData;

        public ShoePicController(
            IShoePicService shoePicService,
            IAiService aiService,
            UserService userService,
            IShoePicData shoePicData,
            IUserData userData,
            ICommentData commentData
            )
        {
            _shoePicService = shoePicService;
            _aiService = aiService;
            _userService = userService;
            _shoePicData = shoePicData;
            _userData = userData;
            _commentData = commentData;
        }

        public IActionResult Index()
        {
            if (UserIsAuthenticated())
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Account/LogIn", "", new { area = "Identity" });
            }
        }

        private bool UserIsAuthenticated()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPic(List<IFormFile> files)
        {
            var filePath = "";
            try
            {
                filePath = await _shoePicService.AddPicToFolder(files);

            }
            catch (Exception e)
            {
                return BadRequest("Filerna måste vara jpg eller png" + e.Message);
            }

            var PredictionAnswer = await _aiService.MakePredictionRequest(filePath);/*new Rootobject
            {
                Predictions = new Prediction[]{
                    new Prediction()
                    {
                        Probability = 0.8F,
                        TagName = "konsultdoja"
                    }
                }
            };*/

            await UploadPicToDataBase(PredictionAnswer, filePath);
            return View("AiResponse", PredictionAnswer);
        }

        private async Task UploadPicToDataBase(Rootobject predictionAnswer, string filePath)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var newUser = await _userService.GetUser(userId);

            foreach (var item in predictionAnswer.Predictions)
            {
                if (item.TagName == "konsultdoja" && item.Probability > 0.7 && item.Probability < 1)
                {
                    _shoePicData.AddPictureToDatabase(new ShoePic
                    {
                        ImageSource = filePath.Substring(8),
                        ApplicationUser = newUser,
                        Probability = item.Probability,
                        Uploaded = DateTime.Now
                    });

                    _userData.AddPointToUser(newUser);

                }
            }
        }

        public IActionResult ShoePicWithComments(int id)
        {
            var shoePic = _shoePicData.GetShoePicWithComments(id);


            return View("ShoePicAndComments", shoePic);
        }

        [HttpPost("AddComment")]
        public IActionResult AddCommentToShoePic(string text, int shoePicId)
        {
            var shoePic = _shoePicData.GetShoePicWithComments(shoePicId);
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var currentUser = _userData.GetUser(currentUserId);
            _commentData.AddComment(text, shoePicId, currentUserId);
            return View("ShoePicAndComments", shoePic);
        }
    }
}
