using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class HearseRepository
    {
        List<Hearse> Hearse;

        public void AddRustvogn(Hearse hearse)
        {
            Hearse.Add(hearse);
        }


        public void CreateHearse(int prio,status status)
        {
            foreach (Hearse i in Hearse)
            {
                if (prio == i.Priority)
                {
                    throw new MemberAccessException();
                }
            }
            Hearse hearse = new Hearse(prio, status);
            Hearse.Add(hearse);
            
        }
        public void AlterHearse(int prio, int cpri)
        {
            foreach (Hearse i in Hearse)
            {
                if (prio == i.Priority)
                {
                    i.Priority = cpri;
                }
            }

        }

        public void GetHearse(int prio)
        {
            Hearse hearse = new Hearse(prio, status.UnChanged);
            Hearse.Add(hearse);
        }
        public void DeleteHearse(int prio)
        {
            foreach(Hearse i in Hearse)
            {
                if (prio == i.Priority)
                {
                    i.Status = status.Deleted;
                }
            }
        }
    }
}
