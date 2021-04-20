using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpoorC1810L.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int Total { get; set; }
        public DateTime DateOfTravel { get; set; }
        public string Class { get; set; }
        public string TrainNo { get; set; }

    }
}
