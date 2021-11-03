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
            List<Car> cars = null;
            if (Session["Cars"]==null || Session["Cars"].ToString() == string.Empty)
            {
               cars = Cars.GetCars(Path);
                Session["Cars"] = cars;               
            }                              
            
            return View(cars);

        }

        public ActionResult DetailView(int CarId)   //Car car
        {
            List<Car> cars = (List<Car>) Session["Cars"];

            Car car = cars.Where(c=>c.Id== CarId).FirstOrDefault();

            return View(car);
        }

      
    }
}