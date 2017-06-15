using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1103105342.Models;

namespace _1103105342
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new _1103105342.Service.ImportService();
            var db = new _1103105342.Repository.StationRepository();
            var stations = import.FindStationData(); //xml
            //stations
            //    .ToList().ForEach(station =>
            //{
            //    db.Create(stations);
            //});
            //var stations = db.FindAllStations();
            ShowStationData(stations);
            Console.ReadLine();
        }
        public static void ShowStationData(List<station> stations)
        {
            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
            stations.ForEach(x =>
            {
                Console.WriteLine(string.Format("名稱：{0}，{1}：{2}{3}", x.River, x.ItemName,x.ItemValue,x.ItemUnit));
            });
        }
    }
}
