using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PNRno { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Total { get; set; }
        public string Class { get; set; }

    }
}
