using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace _1103105342
{
    class Program
    {
        static void Main(string[] args)
        {
            var station = FindStationData();
            ShowStationData(station);
            Console.ReadLine();
        }
        public static List<station> FindStationData()
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
        public static void ShowStationData(List<station> stations)
        {
            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
            stations.ForEach(x =>
            {
                Console.WriteLine(string.Format("地址：{0}，{1}：{2}{3}", x.River, x.ItemName,x.ItemValue,x.ItemUnit));
            });
        }
    }
}
