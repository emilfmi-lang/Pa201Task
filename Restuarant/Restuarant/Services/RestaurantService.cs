using Microsoft.EntityFrameworkCore;
using Restuarant.Data;
using Restuarant.Interfaces;
using Restuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Services
{
    internal class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _context;
        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateRestaurant(Restaurant restaurant)
        {
            if (restaurant == null)
            {
                Console.WriteLine("bos ola bilmez!!!");
                return;
            }
            var result = _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            var data = _context.Restaurants.Find(id);
            if (data != null)
            {
                _context.Restaurants.Remove(data);
            }
            else
            {
                Console.WriteLine("Restoran tapilmadi!!!");
            }
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var data = _context.Restaurants.Find(restaurant.Id);
            if (data == null)
            {
                Console.WriteLine("Restoran tapilmadi");
                return;
            }

            data.Name = restaurant.Name;
            data.Location = restaurant.Location;
            _context.SaveChanges();
        }
    
    }
}
