using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SimpleMVCApplication.Models
{
    public static class Cars
    {
        public static List<Car> GetCars(string documentPath)
        {
            //This is temporary code
            List<Car> MyCars = new List<Car>();


            //Car car = new Car();
            //car.Id = 1;
            //car.Brand = "BMW";
            //car.Model = "Z4";
            //car.TypeofCar = Car.CarType.RoadsterConvertible;
            //car.TransmissionType = Car.Transmission.Automatic;
            //MyCars.Add(car);

            //car = new Car();
            //car.Id = 2;
            //car.Brand = "Kia";
            //car.Model = "Sportage";
            //car.TypeofCar = Car.CarType.SUV;
            //car.TransmissionType = Car.Transmission.Automatic;
            //MyCars.Add(car);

            //car = new Car();
            //car.Id = 3;
            //car.Brand = "Audi";
            //car.Model = "TT";
            //car.TypeofCar = Car.CarType.Convertible;
            //car.TransmissionType = Car.Transmission.Automatic;
            //MyCars.Add(car);

            //car = new Car();
            //car.Id = 4;
            //car.Brand = "Lamborghini";
            //car.Model = "Gallardo";
            //car.TypeofCar = Car.CarType.Coupe;
            //car.TransmissionType = Car.Transmission.Tiptronic;
            //MyCars.Add(car);

            //car = new Car();
            //car.Id = 5;
            //car.Brand = "Mazda";
            //car.Model = "MX-5";
            //car.TypeofCar = Car.CarType.RoadsterConvertible;
            //car.TransmissionType = Car.Transmission.Manual;
            //MyCars.Add(car);

            XmlDocument document = new XmlDocument();
            document.Load(documentPath);

            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                Car car = new Car();
                if (node.ChildNodes.Count > 0)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        switch (childNode.Name)
                        {
                            case "Id":
                                car.Id = Int32.Parse(childNode.InnerText);
                                break;

                            case "Brand":
                                car.Brand = childNode.InnerText;
                                break;

                            case "Model":
                                car.Model = childNode.InnerText;
                                break;

                            case "Colour":
                                car.Colour = childNode.InnerText;
                                break;

                            case "TypeofCar":
                                car.TypeofCar = (Car.CarType)(Convert.ToInt32(childNode.InnerText));
                                break;

                            case "Transmission":
                                car.TransmissionType = (Car.Transmission)(Int32.Parse(childNode.InnerText));
                                break;

                            case "HorsePower":
                                car.HorsePower = Int32.Parse(childNode.InnerText);
                                break;

                            case "MaximumSpeed":
                                car.MaximumSpeed = Int32.Parse(childNode.InnerText);
                                break;

                            case "Mileage":
                                car.Mileage = childNode.InnerText;
                                break;

                            case "Price":
                                car.Price = double.Parse(childNode.InnerText);
                                break;

                            case "Description":
                                car.Description = childNode.InnerText;
                                break;

                            default:
                                car.ImageURL = childNode.InnerText;
                                break;
                        }//End of switch
                    }//End of inner foreach loop
                }//End of inner big if block

                MyCars.Add(car);
            }   //End of foreach


            return MyCars;
        }
    }
}