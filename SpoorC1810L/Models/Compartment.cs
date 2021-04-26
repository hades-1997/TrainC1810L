using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class Compartment
    {
        public int Id { get; set; }
        public string Toa { get; set; }
        public int Numrows { get; set; }
        public int Numcloums { get; set; }
        public int Total { get; set; }
        public Train trains { get; set; }
        public int TrainId { get; set; }
        public ICollection<Chair> chairs { get; set; }
        
    }
}
