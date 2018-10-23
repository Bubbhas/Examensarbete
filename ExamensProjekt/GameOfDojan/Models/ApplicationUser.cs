using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GameOfDojan.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Points{ get; set; }
        public ICollection<ShoePic> ShoePicsList { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
