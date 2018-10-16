using GameOfDojan.ViewModels;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public interface IAiService
    {
        Task<Rootobject> MakePredictionRequest(string imageFilePath);

    }
}