using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> Days { get; set; }
        public string Schedule()
        {
            return $"{StartTime.ToShortTimeString()} - {EndTime.ToShortTimeString()}";
        }
        public List<Student> Students = new List<Student>();
        public Club(int id, string name, DateTime startTime, DateTime endTime, List<string> days)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Days = days;
        }

    }
}
