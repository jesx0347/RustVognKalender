using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EventLibary;
using System.Threading.Tasks;

namespace RustVognKalender
{
    public class DatabaseController
    {
        private readonly string ConnectionString;

        public DatabaseController()
        {
            //string tempsting = Path.GetFullPath("ConnectionString.txt");
            StreamReader reader = new StreamReader(@"..\..\ConnectionString.txt");
            ConnectionString = reader.ReadLine();
            reader.Close();
        }

        public bool CreateEvent(DateTime start, DateTime end, bool reservation, string Address, string Comment)
        {
            string plate = null;
            if (reservation)
            {
                plate = FreeHearse(start, end);
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC dbo.insert_event @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
                command.Parameters.AddWithValue("@START_AT", start);
                command.Parameters.AddWithValue("@END_AT", end);
                command.Parameters.AddWithValue("@VEHICLE", int.Parse(plate));
                command.Parameters.AddWithValue("@AT_ADDRESS", Address);
                command.Parameters.AddWithValue("@COMMENT", Comment);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        private string FreeHearse(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool AlterEvent(int PrimaryKey, string start = null, string end = null, bool reservation = false, string Address = null, string Comment = null)
        {
            DateTime Dstart;
            DateTime Dend;
            if(!DateTime.TryParse(start,out Dstart)||start != null)
            {
                start = null;
            }
            if (!DateTime.TryParse(start, out Dend )||end != null)
            {
                end = null;
            }
            string plate = null;
            if (reservation)
            {
                plate = FreeHearse(DateTime.Parse(start), DateTime.Parse(end));
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC dbo.update_event @KEY @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
                command.Parameters.AddWithValue("@KEY", PrimaryKey);
                command.Parameters.AddWithValue("@START_AT", start);
                command.Parameters.AddWithValue("@END_AT",end);
                command.Parameters.AddWithValue("@VEHICLE", int.Parse(plate));
                command.Parameters.AddWithValue("@AT_ADDRESS", Address);
                command.Parameters.AddWithValue("@COMMENT", Comment);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteEvent(int key)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC dbo.delete_event @KEY";
                command.Parameters.AddWithValue("@KEY", key);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }


        /*
        private string FreeHearse(DateTime start, DateTime end)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("EXEC dbo.GET_HEARSE", connection);
                connection.Open();
                SqlDataReader HearseID = command.ExecuteReader();
                List<int> plateStrings = new List<int>();
                while (HearseID.Read())
                {
                    plateStrings.Add((int)HearseID[0]);
                }
                HearseID.Close();

                command.CommandText = "EXEC dbo.free_at @PRIORITY_";
                SqlDataReader times;

                foreach (int item in plateStrings)
                {
                    command.Parameters.AddWithValue("@PRIORITY_", item);
                    times = command.ExecuteReader();
                    bool isFree = true;
                    while (times.Read())
                    {
                        DateTime startTime = (DateTime)times["START_AT"];
                        DateTime endTime = (DateTime)times["END_AT"];
                        
                        if (!(start > endTime || end < startTime))
                        {
                            isFree = false;
                        }
                    }
                    times.Close();
                    if (isFree)
                    {
                        return item.ToString();
                    }
                    command.Parameters.Clear();
                }
            }
            throw new FileNotFoundException("Ingen rustvogn ledig");
        }
        */



        public List<int> StartUpHearse()
        {
            List<int> result = new List<int>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("EXEC dbo.GET_ALL_HEARSE", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((int)reader["PRIORITY_"]);
                }
            }
            return result;
        }

        public List<Tuple<int,DateTime,DateTime,int, string, string>> StartUpEvents()
        {
            List<Tuple<int, DateTime, DateTime, int, string, string>> result = 
                new List<Tuple<int, DateTime, DateTime, int, string, string>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("EXEC dbo.GET_ALL_EVENTS", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int surrogateKey = (int)reader["SURROGATE_KEY"];
                    DateTime start = (DateTime)reader["START_AT"];
                    DateTime end = (DateTime)reader["END_AT"];
                    int vehicle = (int)reader["VEHICLE"];
                    string address = (string)reader["AT_ADDRESS"];
                    string comment = (string)reader["COMMENT"];

                    Tuple<int, DateTime, DateTime, int, string, string> tuple = 
                        new Tuple<int, DateTime, DateTime, int, string, string>
                        (surrogateKey, start, end, vehicle, address, comment);

                    result.Add(tuple);
                }
            }
            return result;
        }
    }
}
