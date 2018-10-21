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
        void AddPictureToDatabase(ShoePic pic);
       IEnumerable<ShoePic> GetAllShoePicsFromLast7Days();
       ShoePic GetShoePicWithComments(int id);
        //ShoePic GetPicFromFolder(int id);
    }
}
