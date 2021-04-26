using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    [Table("stations")]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Railway railway { get; set; }
        public int RailwayId { get; set; }
        public ICollection<TrainRoute> trainRoutes { get; set; }
        public  Station() {}
    }
}
