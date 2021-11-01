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
            string Path = Server.MapPath("../XML/Cars.xml");

            List<Car> cars = Cars.GetCars(Path);                        
            
            return View(cars);

        }

      
    }
}