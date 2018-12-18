using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class EventRepository
    {
        Dictionary<int,Events> Eventslist;

        public void AddEvent(Events Event)
        {
            
            Eventslist.Add(Eventslist.OrderBy(x => x.Key).Last().Key+1, Event);
        }


        public void CreateEvent(DateTime start, DateTime end, string address, string comment, Hearse hearse = null)
        {
            Events Event = new Events(start,end,address,comment,status.NewlyMade,hearse);

            AddEvent(Event);

        }
        public void alterEvent(int key, string start, string end, string address, string comment, Hearse hearse = null)
        {
            
            if(!(start == null))
            {
                DateTime ostart;
                if (DateTime.TryParse(start,out ostart))
                {
                    Eventslist[key].Start = ostart;
                }
            }
            if (!(end == null))
            {
                DateTime oend;
                if (DateTime.TryParse(end, out oend))
                {
                    Eventslist[key].End = oend;
                }
            }
            if (!(address == null))
            {
                    Eventslist[key].Address = address;
            }
            if (!(comment == null))
            {
                Eventslist[key].Comment= comment;
            }
            if (!(hearse == null))
            {
                Eventslist[key].Hearse = hearse;
            }


        }

        public void GetEvent(DateTime start, DateTime end, string address, string comment, Hearse hearse = null)
        {
            Events Event = new Events(start, end, address, comment, status.UnChanged, hearse);

            AddEvent(Event);

        }
        public void DeleteEvent(int pri)
        {
            Eventslist[pri].Status = status.Deleted;


        }
    }
}
