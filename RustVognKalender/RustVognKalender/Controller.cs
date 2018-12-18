using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventLibary;


namespace RustVognKalender
{
    public class Controller
    {
        DatabaseController DC = new DatabaseController();
        HearseRepository hearseRepository = new HearseRepository();
        EventRepository eventRepository = new EventRepository(hearseRepository);


        public bool CreateEventType(bool reservation, string start,string end, string address,string comment)
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

            return eventRepository.CreateEvent(tstart, tend, address, comment, reservation);
        }
        public bool AlterEvent( string key, bool reservation, string start, string end, string address, string comment)
        {
            int ikey;
            if (int.TryParse(key,out ikey))
            {
                if(start == "") { start = null; }
                if (end == "") { end = null; }
                if (address == "") { address = null; }
                if (comment == "") { comment = null; }
                return DC.AlterEvent(ikey, start, end, reservation, address, comment);
            }
            else
            {
                //Console.WriteLine("Invalid nøgle");
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
                //Console.WriteLine("Invalid nøgle");
                return false;
            }
        }

        public void StartUp()
        {
            foreach (Tuple<int,int> item in DC.StartUpHearse())
            {

            }
        }
    }
}
