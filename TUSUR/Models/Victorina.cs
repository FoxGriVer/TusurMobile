using System;
using System.Collections.Generic;

namespace TUSUR.Models
{
    public class Victorina
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public List<Variant> listOfVariants { get; set; }

        public Victorina()
        {

        }
    }
}
