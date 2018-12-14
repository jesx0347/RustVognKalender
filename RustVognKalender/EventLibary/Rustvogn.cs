using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class Rustvogn
    {
        public int Prioritet;
        public status Status;

        Rustvogn(int pri, status sta)
        {
            Prioritet = pri;
            Status = sta;
        }
    }
}
