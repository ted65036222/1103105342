using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _1103105342.Models;

namespace _1103105342.Service
{
    public class ImportService
    {
        public List<station> FindStationData()
        {
            List<station> stations = new List<station>();
            var xml = XElement.Load(@"C:\Users\ASUS\Desktop\1103105342\opendata.epa.gov.tw.xml");
            var StationsData = xml.Descendants("Data").ToList();
            StationsData
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationData =>
                {
                    var River = stationData.Element("River").Value.Trim();
                    var SampleDate = stationData.Element("SampleDate").Value.Trim();
                    var ItemName = stationData.Element("ItemName").Value.Trim();
                    var ItemValue = stationData.Element("ItemValue").Value.Trim();
                    var ItemUnit = stationData.Element("ItemUnit").Value.Trim();
                    station Data = new station();

                    Data.River = River;
                    Data.SampleDate = SampleDate;
                    Data.ItemName = ItemName;
                    Data.ItemValue = ItemValue;
                    Data.ItemUnit = ItemUnit;
                    stations.Add(Data);
                });
            return stations;
        }
    }
}
