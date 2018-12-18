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
                Hearse hearse = new Hearse(item.Item2, item.Item1, status.UnChanged);
                hearseRepository.AddHearse(hearse);
            }
            foreach (Tuple<int, DateTime, DateTime, int, string, string> item in DC.StartUpEvents())
            {
                Hearse hearse = hearseRepository.GetHearse(item.Item4);
                Events events = new Events(item.Item1, item.Item2, item.Item3, item.Item5, item.Item6, status.UnChanged, hearse)
            }
        }
    }
}
