using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpoorC1810L.Models
{
    [Table("stations")]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Railway railway { get; set; }
        public int RailwayId { get; set; }
        public ICollection<TrainRoute> trainRoutes { get; set; }
        //public ICollection<Train> trains { get; set; }
        public  Station() {}
    }
}
