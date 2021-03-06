using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SimpleMVCApplication.Models;

namespace SimpleMVCApplication.Controllers
{
    public class AddCarController : Controller
    {
        // GET: AddCar
        public ActionResult GetForm()
        {
            SelectList CarTypes = new SelectList(
                new List<SelectListItem>
                {                  
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Convertible), Value = ((int)Car.CarType.Convertible).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Coupe), Value = ((int)Car.CarType.Coupe).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Roadster), Value = ((int)Car.CarType.Roadster).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Sedan), Value = ((int)Car.CarType.Sedan).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.SUV), Value = ((int)Car.CarType.SUV).ToString()}
                }, "Value", "Text");

            SelectList TransmissionTypes = new SelectList(
                new List<SelectListItem>
                {                 
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Automatic), Value = ((int)Car.Transmission.Automatic).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Manual), Value = ((int)Car.Transmission.Manual).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Tiptronic), Value = ((int)Car.Transmission.Tiptronic).ToString()}
                }, "Value", "Text");

            SelectList PricePoints = new SelectList(
                new List<SelectListItem>
                { 
                new SelectListItem { Text= Enum.GetName(typeof(Car.PricePoints), Car.PricePoints.VeryLow) , Value = ((int)Car.PricePoints.VeryLow).ToString() },
                new SelectListItem { Text= Enum.GetName(typeof(Car.PricePoints), Car.PricePoints.Low) , Value = ((int)Car.PricePoints.Low).ToString() },
                new SelectListItem { Text= Enum.GetName(typeof(Car.PricePoints), Car.PricePoints.Medium) , Value = ((int)Car.PricePoints.Medium).ToString() },
                new SelectListItem { Text= Enum.GetName(typeof(Car.PricePoints), Car.PricePoints.High) , Value = ((int)Car.PricePoints.High).ToString() },
                new SelectListItem { Text= Enum.GetName(typeof(Car.PricePoints), Car.PricePoints.VeryHigh) , Value = ((int)Car.PricePoints.VeryHigh).ToString() },
                }, "Value", "Text");

            ViewBag.CarTypes = CarTypes;
            ViewBag.TransmissionTypes = TransmissionTypes;
            ViewBag.PricePoints = PricePoints;

            return View("AddNewCar");
        }

        [HttpPost]
        public ActionResult GetForm(Car car)
        {
            if (ModelState.IsValid)
            {
                //Save model to XML File
                string serverPath = Server.MapPath("../XML/Cars.xml");

                if (car.CarImage.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(car.CarImage.FileName);
                    string newPath = Path.Combine(Server.MapPath("../Images/"), fileName);
                    car.CarImage.SaveAs(newPath);
                    car.ImageURL = "../Images/" + fileName;
                }

                car.SaveNewCar(serverPath);
                Session["AddedNewCar"] = true;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View("AddNewCar", car);
            }
            
        }
    }
}