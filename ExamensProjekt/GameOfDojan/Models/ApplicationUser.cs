using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Points{ get; set; }
        //public List<ShoePic> ShoePicsList { get; set; }
    }
}
