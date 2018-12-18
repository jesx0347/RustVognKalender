﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibary
{
    public class HearseRepository
    {
        // Create a list of hearses
        List<Hearse> Hearse;


        // Adds a hearse to the list
        public void AddHearse(Hearse hearse)
        {
            Hearse.Add(hearse);
        }


        // Create a hearse object that takes two parameters
        public void CreateHearse(int prio,status status)
        {

            // For every hearse in the hearse list do ...
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


        // Alter a hearse object that takes two parameters
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


        // Gets a hearse of the prio key parameter
        public void GetHearse(int prio)
        {
            Hearse hearse = new Hearse(prio, status.UnChanged);
            Hearse.Add(hearse);
        }


        // Deletes a hearse of the prio key parameter
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

        
        // 
        public List<Hearse> GetCopyHearses()
        {
            List<Hearse> result = new List<Hearse>();
            foreach (Hearse item in Hearse)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
