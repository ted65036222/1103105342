using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1103105342.Repository
{
    public class StationRepository
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\1103105342\2.存取資料庫\1103105342\1103105342\App_Data\RiverDB.mdf;Integrated Security=True";
        public void Create(List<Models.station> stations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            foreach (var station in stations)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT          INTO    River(River, SampleDate, ItemName, ItemValue, ItemUnit)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
", station.River, station.SampleDate, station.ItemName, station.ItemValue,station.ItemUnit);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public List<Models.station> FindAllStations()
        {
            var result = new List<Models.station>();
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.ConnectionString = _connectionString;
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from River";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Models.station item = new Models.station();
                item.River = reader["River"].ToString();
                item.SampleDate = reader["SampleDate"].ToString();
                item.ItemName = reader["ItemName"].ToString();
                item.ItemValue = reader["ItemValue"].ToString();
                item.ItemUnit = reader["ItemUnit"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }
    }
}
