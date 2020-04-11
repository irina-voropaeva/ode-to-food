using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;

namespace OdeFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
