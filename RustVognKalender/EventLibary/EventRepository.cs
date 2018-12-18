using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class EventRepository
    {
        List<Events> Eventslist;

        public void AddEvent(Events Event)
        {
            
            Eventslist.Add(Event);
        }


        public void CreateEvent(DateTime start, DateTime end, string address, string comment, Hearse hearse = null)
        {
        
            Events Event = new Events(findHighestKey()+1, start,end,address,comment,status.NewlyMade,hearse);

            AddEvent(Event);

        }
        public void alterEvent(int key, string start, string end, string address, string comment, Hearse hearse = null)
        {
            Events E = new Events(0,DateTime.Now,DateTime.Now,"","",status.Deleted,null);
            foreach (Events i in Eventslist)
            {
                if (i.Key == key)
                {
                    E = i;
                }
            }
            if(!(start == null))
            {
                DateTime ostart;
                if (DateTime.TryParse(start,out ostart))
                {
                    E.Start = ostart;
                }
            }
            if (!(end == null))
            {
                DateTime oend;
                if (DateTime.TryParse(end, out oend))
                {
                    E.End = oend;
                }
            }
            if (!(address == null))
            {
                    E.Address = address;
            }
            if (!(comment == null))
            {
                    E.Comment= comment;
            }
            if (!(hearse == null))
            {
                    E.Hearse = hearse;
            }


        }

        public void GetEvent(int key, DateTime start, DateTime end, string address, string comment, Hearse hearse = null)
        {
            Events Event = new Events(key, start, end, address, comment, status.UnChanged, hearse);

            AddEvent(Event);

        }
        public int findHighestKey()
        {
            int highest = 0;
            foreach(Events i in Eventslist)
            {
                if(i.Key < highest)
                {
                    highest = i.Key;
                }
                
            }
            return highest;
        }
        public List<Events> GetCopyEvents()
        {
            List<Events> tempLists = Eventslist.ToList();
            return tempLists;
        }
        public void DeleteEvent(int key)
        {
            foreach (Events i in Eventslist)
            {
                if (i.Key == key)
                {
                    i.Status = status.Deleted;
                }
            }
        }
    }
}
