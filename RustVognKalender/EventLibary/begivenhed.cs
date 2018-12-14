using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public enum status : byte
    {
         NewlyMade,
         Changed,
         Deleted,
         UnChanged
    }
    public class Begivenhed
    {

        public DateTime Start;
        public DateTime Slut;
        public Rustvogn Rustvogn;
        public string Addresse;
        public string Kommentar;
        public status Status;


        Begivenhed(DateTime start, DateTime slut, string addresse, string kommentar, status status, Rustvogn rustvogn = null)
        {
            Start = start;
            Slut = slut;
            Addresse = addresse;
            Kommentar = kommentar;
            Status = status;
            Rustvogn = rustvogn;
        }
        



         
    }
}
