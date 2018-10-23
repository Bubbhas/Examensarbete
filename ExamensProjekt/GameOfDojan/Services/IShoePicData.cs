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
       IEnumerable<ShoePic> GetLatest12ShoePics();
       ShoePic GetShoePicWithComments(int id);
        void UpdateShoePicDescription(string description, int id);

        //ShoePic GetPicFromFolder(int id);
    }
}
