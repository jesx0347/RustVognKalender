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
            StreamReader reader = new StreamReader(@"C:\Users\bakan\OneDrive\Dokumenter\Datamatiker\Getting Real\c# ting\RustVognKalender\RustVognKalender\RustVognKalender\ConnectionString.txt");
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
                command.CommandText = "EXEC insert_event @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
                command.Parameters.AddWithValue("@START_AT", start);
                command.Parameters.AddWithValue("@END_AT", end);
                command.Parameters.AddWithValue("@VEHICLE", plate);
                command.Parameters.AddWithValue("@AT_ADDRESS", Address);
                command.Parameters.AddWithValue("@COMMENT", Comment);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        
        public bool AlterEvent(int PrimaryKey, string start = null, string end = null, bool reservation = false, string Address = null, string Comment = null)
        {
            string plate = null;
            if (reservation)
            {
                plate = FreeHearse(DateTime.Parse(start), DateTime.Parse(end));
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC update_event @KEY @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
                command.Parameters.AddWithValue("@KEY", PrimaryKey);
                command.Parameters.AddWithValue("@START_AT", DateTime.Parse(start));
                command.Parameters.AddWithValue("@END_AT", DateTime.Parse(end));
                command.Parameters.AddWithValue("@VEHICLE", plate);
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
                command.CommandText = "EXEC delete_event @KEY";
                command.Parameters.AddWithValue("@KEY", key);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        private string FreeHearse(DateTime start, DateTime end)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("EXEC GET_HEARSE", connection);
                connection.Open();
                SqlDataReader plates = command.ExecuteReader();

                command.CommandText = "EXEC free_at @PLATE";
                SqlDataReader times;

                while (plates.Read())
                {
                    string item = (string)plates[0];
                    command.Parameters.AddWithValue("@PLATE", item);
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
                        plates.Close();
                        return item;
                    }
                    command.Parameters.Clear();
                }
                plates.Close();
            }
            throw new Exception("Ingen rustvogn ledig");
        }
    }
}
