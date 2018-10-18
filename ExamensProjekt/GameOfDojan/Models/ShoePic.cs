using System;
using System.Collections.Generic;

namespace GameOfDojan.Models
{
    public class ShoePic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Probability { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public DateTime Uploaded { get; set; }

        public ApplicationUser ApplicationUser{ get; set; }

        public List<Comment> Comments { get; set; }

    }
}
