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
        void AddPointToUser(ApplicationUser newUser);
        //ShoePic Get(int id);
        //ShoePic GetPicFromFolder(int id);
    }
}
