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

        public IEnumerable<ShoePic> GetAllShoePicsFromLast7Days()
        {
            return _context.ShoePics.Where(x => x.Uploaded > DateTime.Today.AddDays(-7)).ToList();
 
            //return  _context.ShoePics.ToList();
        }
    }
}
