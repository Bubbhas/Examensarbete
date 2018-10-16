using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.ViewModels
{

    public class Rootobject
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public string Created { get; set; }
        public Prediction[] Predictions { get; set; }
    }

    public class Prediction
    {
        public float Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }

}
