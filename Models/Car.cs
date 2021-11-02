using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCApplication.Models
{
    /// <summary>
    /// Denotes an instance of a car.
    /// </summary>
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public CarType TypeofCar { get; set; }

        public Transmission TransmissionType { get; set; }

        public int HorsePower { get; set; }

        public int MaximumSpeed { get; set; }

        public string Mileage { get; set; }

        public string Colour { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public Car() {  /* Default constructor */  }

        public enum CarType
        {
            Sedan = 1,
            Coupe,
            Convertible,
            SUV,
            Roadster
        }

        public enum Transmission
        {
            Automatic = 1,
            Manual,
            Tiptronic
        }


    }
}