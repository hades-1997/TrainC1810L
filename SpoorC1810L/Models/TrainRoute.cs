using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class TrainRoute
    {
        public int Id { get; set; }
        public Station station { get; set; }
        public int StationId { get; set; }
        public Train train { get; set; }
        public int TrainId { get; set; }
        public DateTime DepartureTimeTo { get; set; }
        public int Range { get; set; }
        public ICollection<Passenger> passengers { get; set; }

    }
}
