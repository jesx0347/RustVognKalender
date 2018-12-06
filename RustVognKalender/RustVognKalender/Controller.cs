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
            return DC.CreateEvent(resavation, start, end, address, coment);
        }
        public bool AlterEvent( string key, bool resavation, string start, string end, string address, string coment)
        {
            int ikey;
            if (int.TryParse(key,out ikey))
            {
                return DC.AlterEvent(ikey, resavation, start, end, address, coment);
            }
            else
            {
                //Console.WriteLine("invalid key");
                return false;
            }
            
        }
        public bool DeleteEvent(string key)
        {

            return DC.DeleteEvent(key);
            
        }
    }
}
