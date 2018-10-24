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
            var shoePic = _context.ShoePics.Include(x=>x.ApplicationUser)
                .Include(x=>x.Likes)
                .Include(x => x.Comments).ThenInclude(x => x.ApplicationUser)
                .FirstOrDefault(p => p.Id == id);
            //shoePic.Comments = _context.Comments.Where((x => x.Id == id)).ToList();

            return shoePic;
        }

        public IEnumerable<ShoePic> GetLatest12ShoePics()
        {
            return _context.ShoePics.ToList().OrderByDescending(x=>x.Uploaded).Take(12);

        }
        public IEnumerable<ShoePic> GetAllShoePics()
        {
            return _context.ShoePics.ToList();
        }

        public void UpdateShoePicDescription(string description, int id)
        {
            ShoePic shoePic = GetShoePicById(id);
            shoePic.Description = description;
            _context.ShoePics.Update(shoePic);
            _context.SaveChanges();
        }

        public ShoePic GetShoePicById(int id)
        {
            return _context.ShoePics.Where(x => x.Id == id).FirstOrDefault();
        }

        public void GiveShoePicALike(int shoePicId, string currentUserId)
        {
            //var shoePic = _context.Likes.Include(x=>x.ShoePics)
            //    .Include(x=>x.ApplicationUser)
            //    .FirstOrDefault(x=>x.Id == shoePicId);

            _context.Likes.Add(new Likes
            {
                ShoePicId = shoePicId,
                ApplicationUserId = currentUserId
            });
            
            _context.SaveChanges();
        }
    }
}

