using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Interfaces
{
    internal interface IRestaurantService
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int id);
        void CreateRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
    }
}
