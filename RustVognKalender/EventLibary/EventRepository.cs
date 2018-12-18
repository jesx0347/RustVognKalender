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
        HearseRepository HearseRepo;

        public EventRepository(HearseRepository hr)
        {
            HearseRepo = hr;
        }

        public void AddEvent(Events Event)
        {
            
            Eventslist.Add(Event);
        }


        public void CreateEvent(DateTime start, DateTime end, string address, string comment, bool hearseNeded)
        {
            bool free = true;
            foreach (Hearse i in HearseRepo.GetCopyHearses())
            {
                foreach(Events E in Eventslist)
                {
                    if(E.Hearse == i && (( E.Start > end) || E.End < start))
                    {
                        free = false;
                    }
                }
                if (free)
                {
                    Events Event = new Events(findHighestKey() + 1, start, end, address, comment, status.NewlyMade, i);
                    AddEvent(Event);
                }
                else
                {
                    free = true;
                }
            }
        
            

            

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
            if (E.Key == 0)
            {
                throw new IndexOutOfRangeException("key not found");
            }
            if(!(start == null))
            {
                DateTime ostart;
                if (DateTime.TryParse(start,out ostart))
                {
                    bool free = true;
                    foreach (Hearse i in HearseRepo.GetCopyHearses())
                    {
                        foreach (Events e in Eventslist)
                        {
                            if (E.Hearse == i && !())
                            {
                                free = false;
                            }
                        }
                        if (free)
                        {
                            E.Start = ostart;
                        }
                        else
                        {
                            free = true;
                        }
                    }
                    
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
            if (!(E.Status == status.NewlyMade))
            {
                E.Status = status.Changed;
            }


        }

        public void StartUpEvent(int key, DateTime start, DateTime end, string address, string comment, Hearse hearse = null)
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
