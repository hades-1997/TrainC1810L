using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class BookingTicket
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public Passenger passenger { get; set; }
        public int PassengerId { get; set; }
        public Chair chair { get; set; }
        public int ChairId { get; set; }
    }
}
