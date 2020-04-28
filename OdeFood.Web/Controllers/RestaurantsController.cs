using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;

namespace OdeFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData restaurantData)
        {
            db = restaurantData;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return model == null ? View("NotFound") : View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (!ModelState.IsValid) return View(restaurant);
            db.Edit(restaurant);
            return RedirectToAction("Details", restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid) return View(restaurant);
            db.Add(restaurant);
            return RedirectToAction("Details", restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Details");
        }
    }
}