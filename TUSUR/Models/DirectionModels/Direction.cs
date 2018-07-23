using System;
namespace TUSUR.Models.DirectionModels
{
    public class Direction
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int PayPlaces { get; set; }
        public int FreePlaces { get; set; }
        public int Price { get; set; }
        public int MinBall { get; set; }

        public Direction()
        {
            
        }
    }
}
