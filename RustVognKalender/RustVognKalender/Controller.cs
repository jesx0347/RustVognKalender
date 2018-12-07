using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustVognKalender
{
    public class Controller
    {
        DatabaseController DC = new DatabaseController();

        public bool CreateEventType(bool resavation, string start,string end, string address,string coment)
        {
            DateTime tend;
            DateTime tstart;
            if (!DateTime.TryParse(start, out tstart))
            {
                return false;
            }
            if (!DateTime.TryParse(end, out tend))
            {
                return false;
            }

            return DC.CreateEvent(tstart, tend, resavation, address, coment);
        }
        public bool AlterEvent( string key, bool resavation, string start, string end, string address, string coment)
        {
            int ikey;
            if (int.TryParse(key,out ikey))
            {
                if(start == "") { start = null; }
                if (end == "") { end = null; }
                if (address == "") { address = null; }
                if (coment == "") { coment = null; }
                return DC.AlterEvent(ikey, start, end, resavation, address, coment);
            }
            else
            {
                //Console.WriteLine("invalid key");
                return false;
            }
            
        }
        public bool DeleteEvent(string key)
        {
            int ikey;
            if (int.TryParse(key, out ikey))
            {
                return DC.DeleteEvent(ikey);
            }
            else
            {
                //Console.WriteLine("invalid key");
                return false;
            }
        }
    }
}
