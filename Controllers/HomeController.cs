using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleMVCApplication.Models;

namespace SimpleMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            List<Car> cars = Cars.GetCars();                        
            
            return View(cars);

        }

      
    }
}