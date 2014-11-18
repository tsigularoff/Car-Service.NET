namespace CarService.Web.Common
{
    using System;

    public class GeoDistance
    {
        public static double GetDistance(GeoPoint p1, GeoPoint p2)
        {
            var R = 6378137;
            var dLat = ConvertToRadian(p2.Lat - p1.Lat);
            var dLong = ConvertToRadian(p2.Lng - p1.Lng);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(ConvertToRadian(p1.Lat)) * Math.Cos(ConvertToRadian(p2.Lat)) *
              Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d / 1000; // returns the distance in meter
        }

        private static double ConvertToRadian(double x)
        {
            return (x * Math.PI / 180);
        }
    }
}