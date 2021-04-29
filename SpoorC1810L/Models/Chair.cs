using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    [Serializable]
    public class Chair
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public int Price { get; set; }
        public Compartment compartment { get; set; }
        public int CompartmentId { get; set; }
    }
}
