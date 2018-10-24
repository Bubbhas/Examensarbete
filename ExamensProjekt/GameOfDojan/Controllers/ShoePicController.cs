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
                return true;
            else
                return false;
        }

        public IActionResult AllShoePics()
        {
            var shoePics = _shoePicData.GetAllShoePics();


            return View("AllShoePics", shoePics);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPic(List<IFormFile> files)
        {
            var filePath = "";
            try
            {
                filePath = await _shoePicService.AddPicToFolder(files);
            }
            catch (Exception)
            {
                return BadRequest();
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

            var shoePic = await CreateShoePic(PredictionAnswer, filePath);
            UploadPicToDataBase(shoePic);
            return View("AiResponse", shoePic);
        }

        public IActionResult GiveShoePicALike(int id)
        {
         
            if (UserIsAuthenticated())
            {
                var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                try
                {
                    _shoePicData.GiveShoePicALike(id, currentUserId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
                var shoePic = _shoePicData.GetShoePicWithComments(id);
                return View("ShoePicWithComments", shoePic);
            }
            else
            {
                return RedirectToPage("/Account/LogIn", "", new { area = "Identity" });
            }

        }

        private async Task<ShoePic> CreateShoePic(Rootobject predictionAnswer, string filePath)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var newUser = await _userService.GetUser(userId);

            var shoePic = new ShoePic
            {
                ImageSource = filePath.Substring(8),
                ApplicationUser = newUser,
                Uploaded = DateTime.Now
            };

            foreach (var item in predictionAnswer.Predictions)
            {
                if (item.TagName == "konsultdoja")
                    shoePic.Probability = item.Probability;
            }
            return shoePic;
        }

        private void UploadPicToDataBase(ShoePic shoePic)
        {
            if (shoePic.Probability > 0.7 && shoePic.Probability < 1)
            {
                _shoePicData.AddPictureToDatabase(shoePic);
                _userData.AddPointToUser(shoePic.ApplicationUser);
            }
        }

        public IActionResult ShoePicWithComments(int id)
        {
            var shoePic = _shoePicData.GetShoePicWithComments(id);
            return View("ShoePicWithComments", shoePic);
        }

        //[HttpPost("AddComment")]
        public IActionResult AddCommentToShoePic(string text, int shoePicId)
        {
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var currentUser = _userData.GetUser(currentUserId);
            _commentData.AddComment(text, shoePicId, currentUserId);
            var shoePic = _shoePicData.GetShoePicWithComments(shoePicId);

            return View("ShoePicWithComments", shoePic);
        }

        public IActionResult UpdateDescriptionToShoePic(string description, int shoePicId)
        {
            _shoePicData.UpdateShoePicDescription(description, shoePicId);
            var shoePic = _shoePicData.GetShoePicWithComments(shoePicId);
            return View("ShoePicWithComments", shoePic);
        }
    }
}
