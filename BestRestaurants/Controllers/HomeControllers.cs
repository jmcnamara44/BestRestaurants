using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            // List<Restaurant> RestaurantList = Restaurant.GetAll();
            return View();
        }
        [HttpGet("/output")]
        public ActionResult Output()
        {
            List<Restaurant> restaurantList = Restaurant.GetAll();
            return View(restaurantList);
        }
    }
}
