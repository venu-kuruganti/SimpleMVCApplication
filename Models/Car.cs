using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml;

namespace SimpleMVCApplication.Models
{
    /// <summary>
    /// Denotes an instance of a car.
    /// </summary>
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        
        [Required]
        [Display(Name ="Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Car type is required")]
        [Display(Name ="Type of Car")]
        public CarType TypeofCar { get; set; }

        [Required(ErrorMessage = "Transmission type is required")]
        [Display(Name ="Transmission Type")]
        public Transmission TransmissionType { get; set; }

        [Display(Name ="Engine HP")]
        public int HorsePower { get; set; }

        [Display(Name ="Maximum Speed")]
        public int MaximumSpeed { get; set; }

        [Display(Name ="Economy /  MPG")]
        public string Mileage { get; set; }

        [Required]
        [Display(Name ="Colour")]
        public string Colour { get; set; }
                
        [Display(Name ="Car Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Price")]
        [Range(10000, 1000000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Car Photo")]
        public HttpPostedFileBase CarImage { get; set; }

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

        public bool SaveNewCar(string Path)
        {
            bool success = true;

            try
            {


                XmlDocument XDoc = new XmlDocument();
                XDoc.Load(Path);
                int lastId = Convert.ToInt32(XDoc.LastChild.LastChild.ChildNodes[0].InnerText); //for creating a new ID

                XmlNode node = XDoc.CreateNode(XmlNodeType.Element, "Car", null);

                XmlNode child = XDoc.CreateNode(XmlNodeType.Element, "Id", null);
                child.InnerText = (++lastId).ToString();
                node.AppendChild(child);

                child = XDoc.CreateNode(XmlNodeType.Element, "Brand", null);
                child.InnerText = Brand;
                node.AppendChild(child);

                child = XDoc.CreateNode(XmlNodeType.Element, "Model", null);
                child.InnerText = Model;
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "Colour", null);
                child.InnerText = Colour;
                node.AppendChild(child);

                child = XDoc.CreateNode(XmlNodeType.Element, "TypeofCar", null);
                child.InnerText =  ((int)TypeofCar).ToString();
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "Transmission", null);
                child.InnerText = ((int)TransmissionType).ToString();
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "HorsePower", null);
                child.InnerText = HorsePower.ToString();
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "MaximumSpeed", null);
                child.InnerText = MaximumSpeed.ToString();
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "Mileage", null);
                child.InnerText = Mileage;
                node.AppendChild(child);


                child = XDoc.CreateNode(XmlNodeType.Element, "Price", null);
                child.InnerText = Price.ToString();
                node.AppendChild(child);

                child = XDoc.CreateNode(XmlNodeType.Element, "Description", null);
                child.InnerText = Description;
                node.AppendChild(child);

                child = XDoc.CreateNode(XmlNodeType.Element, "ImageURL", null);
                child.InnerText = ImageURL;
                node.AppendChild(child);

                XDoc.DocumentElement.AppendChild(node);

                XDoc.Save(Path);

                return success;
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
        }
    }
}