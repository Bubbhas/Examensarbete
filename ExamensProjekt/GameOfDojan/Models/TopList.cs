using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameOfDojan.Models
{
    public class TopList 
    {
        //public int Id { get; set; }

        public IEnumerable<ApplicationUser> User { get; set; }
        //public string UserName { get; set; }

        public IEnumerable<ShoePic> ShoePic { get; set; }
    }
}
