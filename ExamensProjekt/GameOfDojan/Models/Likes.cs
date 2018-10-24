using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Models
{
    public class Likes
    {
        public DateTime DateOfLike { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ShoePicId { get; set; }
        public ShoePic ShoePic { get; set; }
    }
}
