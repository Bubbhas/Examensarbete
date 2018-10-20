using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfDojan.Models;

namespace GameOfDojan.Services
{
    public interface IUserData
    {
        void AddPointToUser(ApplicationUser newUser);
        ApplicationUser GetUser(string id);
        ApplicationUser GetUserByUserName(string userName);
        IEnumerable<ApplicationUser> GetAllUsers();
    }
}