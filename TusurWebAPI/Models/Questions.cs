using System;
using System.Collections.Generic;

namespace TusurWebAPI.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public List<Variants> ListOfVariants { get; set; }
        public bool IsPast { get; set; }

        public Questions()
        {
            ListOfVariants = new List<Variants>();
        }
    }
}
