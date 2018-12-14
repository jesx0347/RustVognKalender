using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class Rustvogn
    {
        public int Key;
        public int Prioritet;
        public status Status;

        public Rustvogn(int pri, status sta)
        {
            
            Prioritet = pri;
            Status = sta;
        }
        public Rustvogn(int key,int pri, status sta) : this(pri,sta)
        {
            Key = key;
        }
        public override bool Equals(object obj)
        {
            if (obj is Rustvogn)
            {
                if (this.Prioritet == (obj as Rustvogn).Prioritet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
