using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
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

        public void AddPointToUser(ApplicationUser newUser)
        {
            newUser.Points += 10;

            _context.SaveChanges();
        }

        public ShoePic Get(int id)
        {
            return _context.ShoePics.FirstOrDefault(p => p.Id == id);
        }
    }
}
