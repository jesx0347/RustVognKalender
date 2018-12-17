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
    public class Events
    {

        public DateTime Start;
        public DateTime End;
        public Hearse Hearse;
        public string Address;
        public string Comment;
        public status Status;


        public Events(DateTime start, DateTime end, string address, string comment, status status, Hearse hearse = null)
        {
            Start = start;
            End = end;
            Address = address;
            Comment = comment;
            Status = status;
            Hearse = hearse;
        }
        



         
    }
}
