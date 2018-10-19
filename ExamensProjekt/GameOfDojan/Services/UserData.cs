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
            return _context.ApplicationUsers.Include(x => x.ShoePicsList).FirstOrDefault(x => x.Id == id);
        }

        public List<ApplicationUser> GetTop10UserPoints()
        {
            var listOfUsers = new List<ApplicationUser>();

            return listOfUsers;
        }
        public ApplicationUser GetUserByUserName(string userName)
        {
            return _context.ApplicationUsers.FirstOrDefault(x => x.UserName == userName);

        }
    }
}
