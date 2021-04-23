using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class BookingTicket
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Total { get; set; }
        public DateTime DateOfTravel { get; set; }
        public string TrainNo { get; set; }

    }
}
