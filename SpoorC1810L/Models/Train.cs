using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpoorC1810L.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string RouteFromTo { get; set; }
        public DateTime DepartureTime { get; set; }
        public int Compartment { get; set; }
        public int OneAC { get; set; }
        public int TwoAC { get; set; }
        public int ThreeAC { get; set; }
        public int Sleeper { get; set; }
        public int General { get; set; }
        public ICollection<TrainRoute> trainRoutes { get; set; }
    }
}
