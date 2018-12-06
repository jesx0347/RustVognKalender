using System;
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

        public bool CreateEvent(bool resavation, DateTime start, DateTime end, string Address, string Comment)
        {
            throw new NotImplementedException();
        }
        
        public bool AlterEvent(int PrimaryKey, bool resavation, string start = null, string end = null, string Address = null, string Comment = null)
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
