using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class Hearse
    {
        public int Key;
        public int Priority;
        public status Status;

        public Hearse(int prio, status sta)
        {
            
            Priority = prio;
            Status = sta;
        }
        public Hearse(int key,int prio, status sta) : this(prio,sta)
        {
            Key = key;
        }
        public override bool Equals(object obj)
        {
            if (obj is Hearse)
            {
                if (this.Priority == (obj as Hearse).Priority)
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
