using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public interface IShoePicData
    {
        ShoePic Get(int id);
        ShoePic GetPicFromFolder(int id);
    }
}
