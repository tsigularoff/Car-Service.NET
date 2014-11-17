namespace CarService.Data.SeedData
{
    using System;
    using System.Xml.Linq;    
    using System.Linq;    
    using System.Collections.Generic;
    using System.Text;

    using CarService.Models;

    public class XMLGasStationReader
    {
        private const string DefaulImagePath = "/Imgs/Logos/noimage.jpg";

        public XMLGasStationReader()
        {            
        }
        public ICollection<CarServiceCenter> GetServiceCenters(string path)
        {
            var xmlData = XElement.Load(path);

            var xmlWaypoints = xmlData.Elements();

            var serviceCenters = new List<CarServiceCenter>();

            foreach (var xmlWayPoint in xmlWaypoints)
            {
                if (xmlWayPoint.Name != "wpt")
                {
                    continue;
                }

                serviceCenters.Add(new CarServiceCenter
                    {
                        Name = this.GetName(xmlWayPoint),
                        Location = this.GetLocation(xmlWayPoint),                       
                        StreetAddress = this.GetAddress(xmlWayPoint),                        
                        City = this.GetCity(xmlWayPoint),
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        ImgUrl = DefaulImagePath
                    });
            }

            return serviceCenters;
        }        

        private string GetName(XElement xmlWayPoint)
        {
            if (xmlWayPoint.Element("name") != null)
            {
                var name = xmlWayPoint.Element("name").Value;
                name = name.Replace("Shell", "");
                return name;
            }
            else
            {
                throw new ArgumentException("Gas station cannot be null or emoty");
            }
        }

        private string GetLocation(XElement xmlWayPoint)
        {
            var lat = xmlWayPoint.FirstAttribute.Value;
            var lon = xmlWayPoint.LastAttribute.Value;

            return string.Format("{0};{1}", lat, lon);
        }               

        private string GetAddress(XElement xmlWayPoint)
        {
            var address = xmlWayPoint.Element("extensions")
                                        .Element("WaypointExtension")
                                        .Element("Address")
                                        .Element("StreetAddress").Value;            
            return address;
        }

        private string GetCity(XElement xmlWayPoint)
        {
            var city = xmlWayPoint.Element("extensions")
                                        .Element("WaypointExtension")
                                        .Element("Address")
                                        .Element("City").Value;            
            return city;
        }
    }
}
