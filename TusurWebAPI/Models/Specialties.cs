using System;
using System.Collections.Generic;

namespace TusurWebAPI.Models
{
    public class Specialties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int FreePlaces { get; set; }
        public int PayPlaces { get; set; }
        public int StartNumberOfPointsInPastYear { get; set; }
        public int Price { get; set; }
        public double Duration { get; set; }
        public string Qualification { get; set; }
        public string Testing { get; set; }
        public List<Profiles> ListOfProfiles { get; set; }

        public Specialties()
        {
            ListOfProfiles = new List<Profiles>();
        }
    }
}
