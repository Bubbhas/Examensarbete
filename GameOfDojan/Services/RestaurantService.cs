using System.Linq;

namespace GameOfDojan.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantService(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public string CountMessage()
        {
            return "Antal restauranger är " + _restaurantData.GetAll().Count();
        }
    }
}
