using System;
using System.Collections.Generic;
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
                    new SelectListItem { Text = "--Please Select Car Type--", Value = "-1"},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Convertible), Value = ((int)Car.CarType.Convertible).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Coupe), Value = ((int)Car.CarType.Coupe).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Roadster), Value = ((int)Car.CarType.Roadster).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.Sedan), Value = ((int)Car.CarType.Sedan).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.CarType), Car.CarType.SUV), Value = ((int)Car.CarType.SUV).ToString()}
                }, "Value", "Text", "-1");

            SelectList TransmissionTypes = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "--Please Select Transmission Type--", Value = "-1"},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Automatic), Value = ((int)Car.Transmission.Automatic).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Manual), Value = ((int)Car.Transmission.Manual).ToString()},
                    new SelectListItem { Text = Enum.GetName(typeof(Car.Transmission), Car.Transmission.Tiptronic), Value = ((int)Car.Transmission.Tiptronic).ToString()}
                }, "Value", "Text", "-1");            

            ViewBag.CarTypes = CarTypes;
            ViewBag.TransmissionTypes = TransmissionTypes;

            return View("AddNewCar");
        }

        [HttpPost]
        public ActionResult GetForm(Car car)
        {
            if (ModelState.IsValid)
            {
                //Save model to XML File
                string Path = Server.MapPath("../XML/Cars.xml");

                car.SaveNewCar(Path);

                return View(new Car());
            }
            else
            {
                return View(car);
            }
            
        }
    }
}