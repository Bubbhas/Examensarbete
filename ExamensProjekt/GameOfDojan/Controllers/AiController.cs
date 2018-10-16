using GameOfDojan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Controllers
{
    public class AiController
    {
        private readonly IAiService _aiService;
        public AiController(AiService aiService)
        {
            _aiService = aiService;
        }


    }
}
