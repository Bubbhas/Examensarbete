using System.Collections.Generic;
using System.Linq;
using GameOfDojan.Models;
using GameOfDojan.Data;
using Microsoft.EntityFrameworkCore;

namespace GameOfDojan.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private GameOfDojanDbContext _context;

        public SqlRestaurantData(GameOfDojanDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Attach(restaurant).State = 
                EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }

        public void Remove(int id)
        {
            var r = _context.Restaurants.First(x => x.Id == id);
            _context.Restaurants.Remove(r);
            _context.SaveChanges();
        }
    }
}
