using GameOfDojan.Data;
using GameOfDojan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public class CommentData : ICommentData
    {
        private readonly GameOfDojanDbContext _context;

        public CommentData(GameOfDojanDbContext context)
        {
            _context = context;
        }


        public void AddComment(string text, int picId, string currentUserId)
        {

           
            var shoeComment = new Comment
            {
                Text = text,
                ShoePicId = picId,
                ApplicationUserId = currentUserId,
                CreateDate = DateTime.Now
            };
            _context.Comments.Add(shoeComment);
            _context.SaveChanges();
        }
    }
}
