﻿using GameOfDojan.Models;
using System.Collections.Generic;

namespace GameOfDojan.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
        void Remove(int id);
    }
}