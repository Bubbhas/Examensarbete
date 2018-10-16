using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public interface IHttpService
    {
        Task<string> Get(string url);
    }
}