﻿using System;
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

        public bool CreateEvent(string start, string end, bool reservation, string Address, string Comment)
        {
            string plate = null;
            if (reservation)
            {
                plate = FreeHearse(DateTime.Parse(start), DateTime.Parse(end));
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "EXEC insert_event @START_AT, @END_AT, @VEHICLE, @AT_ADDRESS, @COMMENT";
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
        
        public bool AlterEvent(int PrimaryKey, string start = null, string end = null, bool reservation = false, string Address = null, string Comment = null)
        {
            Convert.ToDateTime(start);
            throw new NotImplementedException();
        }

        public bool DeleteEvent(string key)
        {

            throw new NotImplementedException();
        }

        private string FreeHearse(DateTime start, DateTime end)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("EXEC get_hearse", connection);
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
            throw new Exception("no vehicle availlable");
        }
    }
}
