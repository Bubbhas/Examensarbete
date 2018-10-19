using GameOfDojan.Data;
using GameOfDojan.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameOfDojan.Services
{
    public class UserData : IUserData
    {
        private readonly GameOfDojanDbContext _context;

        public UserData(GameOfDojanDbContext context)
        {
            _context = context;
        }

        public void AddPointToUser(ApplicationUser User)
        {
            User.Points += 10;

            _context.SaveChanges();
        }

        public ApplicationUser GetUser(string id)
        {
            var user = _context.ApplicationUsers.Include(x => x.ShoePicsList).FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<ApplicationUser> GetTop10UserPoints()
        {
            var listOfUsers = new List<ApplicationUser>();

            return listOfUsers;
        }
    }
}
