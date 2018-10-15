using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public class ShoePicData : IShoePicData
    {
        private readonly GameOfDojanDbContext _context;

        public ShoePicData(GameOfDojanDbContext context)
        {
            _context = context;
        }

        public void AddPictureToFolder()
        {

        }

        //public ShoePic GetPicFromFolder(int id)
        //{
        //    return ShoePic; 
        //} 

        public ShoePic Get(int id)
        {
            return _context.ShoePics.FirstOrDefault(p => p.Id == id);
        }
    }
}
