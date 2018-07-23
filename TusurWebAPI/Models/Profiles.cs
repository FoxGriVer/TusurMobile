using System;
namespace TusurWebAPI.Models
{
    public class Profiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpecialityId { get; set; }

        public Profiles()
        {
        }
    }
}
