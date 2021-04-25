using SpoorC1810L.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class TemporaryBooking
    {
        public int Id { get; set; }
        public int TrainsId { get; set; }
        public int Trainno { get; set; }
        public string Name { get; set; }
        public int total { get; set; }
        public int Seats { get; set; }

    }
}
