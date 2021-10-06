using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCApplication.Models
{
    public static class Cars
    {
        public static List<Car> GetCars()
        {
            //This is temporary code
            List<Car> MyCars = new List<Car>();


            Car car = new Car();
            car.Id = 1;
            car.Brand = "BMW";
            car.Model = "Z4";
            car.TypeofCar = Car.CarType.RoadsterConvertible;
            car.TransmissionType = Car.Transmission.Automatic;
            MyCars.Add(car);

            car = new Car();
            car.Id = 2;
            car.Brand = "Kia";
            car.Model = "Sportage";
            car.TypeofCar = Car.CarType.SUV;
            car.TransmissionType = Car.Transmission.Automatic;
            MyCars.Add(car);

            car = new Car();
            car.Id = 3;
            car.Brand = "Audi";
            car.Model = "TT";
            car.TypeofCar = Car.CarType.Convertible;
            car.TransmissionType = Car.Transmission.Automatic;
            MyCars.Add(car);

            car = new Car();
            car.Id = 4;
            car.Brand = "Lamborghini";
            car.Model = "Gallardo";
            car.TypeofCar = Car.CarType.Coupe;
            car.TransmissionType = Car.Transmission.Tiptronic;
            MyCars.Add(car);

            car = new Car();
            car.Id = 5;
            car.Brand = "Mazda";
            car.Model = "MX-5";
            car.TypeofCar = Car.CarType.RoadsterConvertible;
            car.TransmissionType = Car.Transmission.Manual;
            MyCars.Add(car);


            return MyCars;
        }
    }
}