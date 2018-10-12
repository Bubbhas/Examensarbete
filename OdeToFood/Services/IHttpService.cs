using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IHttpService
    {
        Task<string> Get(string url);
    }
}