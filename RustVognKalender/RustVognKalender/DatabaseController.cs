using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RustVognKalender
{
    public class DatabaseController
    {
        private string ConnectionString;

        public DatabaseController()
        {
            StreamReader reader = new StreamReader(@"\..\..\ConnectionString.txt");
            ConnectionString = reader.ReadLine();
            reader.Close();
        }

        public bool CreateEvent(string start, string end, string Address, string Comment)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC insert_event @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
                command.Parameters.AddWithValue("@START_AT", DateTime.Parse(start));
                command.Parameters.AddWithValue("@END_AT", DateTime.Parse(end));
                command.Parameters.AddWithValue("@AT_ADDRESS", Address);
                command.Parameters.AddWithValue("@COMMENT", Comment);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }

            return false;
        }
        
        public bool AlterEvent(int PrimaryKey, string start = null, string end = null, string Address = null, string Comment = null)
        {
            Convert.ToDateTime(start);
            throw new NotImplementedException();
        }

        public bool DeleteEvent(string key)
        {

            throw new NotImplementedException();
        }
    }
}
