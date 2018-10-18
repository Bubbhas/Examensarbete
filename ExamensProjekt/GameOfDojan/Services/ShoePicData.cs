using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddPictureToDatabase(ShoePic pic)
        {
            _context.ShoePics.Add(pic);

            _context.SaveChanges();
        }
        
        public ShoePic Get(int id)
        {
            return _context.ShoePics.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ShoePic> GetAllShoePics()
        {
            return  _context.ShoePics.ToList();
        }
    }
}
