using GameOfDojan.Models;
using System.Collections.Generic;

namespace GameOfDojan.Services
{
    public interface IShoePicData
    {
        void AddPictureToDatabase(ShoePic pic);
       IEnumerable<ShoePic> GetLatest12ShoePics();
       ShoePic GetShoePicWithComments(int id);
        void UpdateShoePicDescription(string description, int id);
        void GiveShoePicALike(int shoePicId, string currentUserId);
        IEnumerable<ShoePic> GetAllShoePics();
        //ShoePic GetPicFromFolder(int id);
    }
}
