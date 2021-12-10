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
        [HttpGet]
        public ActionResult Home()
        {
            string Path;
            try
            {
                Path = Server.MapPath("../XML/Cars.xml");
            }
            catch
            {
                Path = Server.MapPath("XML/Cars.xml");
            }                
           
            Cars cars = new Cars();
            cars.DocumentPath = Path;

            if (Session["Cars"] == null || (bool)Session["AddedNewCar"])
            {
                cars.PopulateCars();
                Session["Cars"] = cars;
            }
            else
                cars = (Cars)Session["Cars"];
            
            return View(cars);

        }

        public ActionResult DetailView(int CarId)   //Car car
        {
            Cars cars = (Cars) Session["Cars"];

            Car car = cars.MyCars.Where(c=>c.Id== CarId).FirstOrDefault();

            return View(car);
        }

      
    }
}