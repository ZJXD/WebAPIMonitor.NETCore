using System;
using System.Collections.Generic;
using System.Text;

namespace ReadCSV
{
    /// <summary>
    /// POI 信息
    /// </summary>
    public class POIInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string CityCode { get; set; }

        public string Type { get; set; }

        public int Filed1 { get; set; }

        public int Filed2 { get; set; }
    }
}
