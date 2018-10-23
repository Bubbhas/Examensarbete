using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
        
        public ShoePic GetShoePicWithComments(int id)
        {
            var shoePic = _context.ShoePics.Include(x => x.Comments).Include(x => x.ApplicationUser).FirstOrDefault(p => p.Id == id);
            shoePic.Comments = _context.Comments.Where((x => x.Id == id)).ToList();

            return shoePic;
        }

        public IEnumerable<ShoePic> GetAllShoePicsFromLast7Days()
        {
            return _context.ShoePics.Where(x => x.Uploaded > DateTime.Today.AddDays(-7)).ToList();
 
            //return  _context.ShoePics.ToList();
        }
    }
}
