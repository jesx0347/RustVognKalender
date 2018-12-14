using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class RustvognReposetory
    {
        List<Rustvogn> Rustvognen;

        public void AddRustvogn(Rustvogn rustvogn)
        {
            Rustvognen.Add(rustvogn);
        }


        public void CreateRustvogn(int pri,status status)
        {
            foreach (Rustvogn i in Rustvognen)
            {
                if (pri == i.Prioritet)
                {
                    throw new MemberAccessException();
                }
            }
            Rustvogn rustvogn = new Rustvogn(pri, status);
            Rustvognen.Add(rustvogn);
            
        }
        public void alterRustvogn(int pri, int cpri)
        {
            foreach (Rustvogn i in Rustvognen)
            {
                if (pri == i.Prioritet)
                {
                    i.Prioritet = cpri;
                }
            }

        }

        public void getRustvogn(int pri)
        {
            Rustvogn rustvogn = new Rustvogn(pri, status.UnChanged);
            Rustvognen.Add(rustvogn);
        }
        public void DeleteRustvogn(int pri)
        {
            foreach(Rustvogn i in Rustvognen)
            {
                if (pri == i.Prioritet)
                {
                    i.Status = status.Deleted;
                }
            }
        }
    }
}
