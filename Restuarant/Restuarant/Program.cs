// See https://aka.ms/new-console-template for more information
using Restuarant.Data;
using Restuarant.Interfaces;
using Restuarant.Models;
using Restuarant.Services;

//Console.WriteLine("Hello, World!");
var context = new AppDbContext();
RestaurantService restaurantService = new RestaurantService(context);

//restaurantService.CreateRestaurant(new Restaurant
//{
//    Name = "Sheki Palace",
//    Location = "Sheki",
//    MaxTables = 15
//});

context.Restaurants.AddRange(
    new Restaurant { Name = "Etiler", Location = "Cresent Mall", MaxTables = 15 },
    new Restaurant { Name = "KFC", Location = "Sahil M", MaxTables = 21 },
    new Restaurant { Name = "Nakhchivan House", Location = "28 May", MaxTables = 20 },
    new Restaurant { Name = "Old City Pub", Location = "Icherisheher", MaxTables = 12 }
    );
context.SaveChanges();


