﻿using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Pizza", Cuisine = CuisineType.Italian},
                new Restaurant() { Id = 1, Name = "Franch", Cuisine = CuisineType.French},
                new Restaurant() { Id = 1, Name = "Mango Groove", Cuisine = CuisineType.Indian},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        }

        public void Edit(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing == null) return;
            existing.Name = restaurant.Name;
            existing.Cuisine = restaurant.Cuisine;
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}