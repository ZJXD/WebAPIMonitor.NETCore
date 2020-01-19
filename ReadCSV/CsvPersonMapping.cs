using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace ReadCSV
{
    public class CsvPOIInfoMapping: CsvMapping<POIInfo>
    {
        public CsvPOIInfoMapping():base()
        {
            MapProperty(0,x=>x.Id);
            MapProperty(1, x => x.Name);
            MapProperty(2, x => x.Address);
            MapProperty(3, x => x.Longitude);
            MapProperty(4, x => x.Latitude);
            MapProperty(5, x => x.CityCode);
            MapProperty(6, x => x.Type);
            MapProperty(7, x => x.Filed1);
            MapProperty(8, x => x.Filed2);
        }
    }
}
