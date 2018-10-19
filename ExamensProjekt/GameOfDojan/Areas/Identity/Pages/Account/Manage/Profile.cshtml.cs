using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfDojan.Models;
using GameOfDojan.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameOfDojan.Areas.Identity.Pages.Account.Manage
{
    public partial class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserData _userData;


        public ProfileModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserData userData
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userData = userData;

        }

        public ApplicationUser CurrentUser { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class OutputModel
        {
            public string UserName { get; set; }

            public int Points { get; set; }

            public ICollection<ShoePic> UserShoePicList{ get; set; }
        }

        public async Task OnGetAsync()
        {
             CurrentUser = _userData.GetUser(_userManager.GetUserId(User));

            
        }
    }
}