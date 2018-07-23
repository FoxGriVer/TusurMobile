using System;

namespace TusurWebAPI.Models
{
    public class Variants
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }

        public Variants()
        {
        }
    }
}
