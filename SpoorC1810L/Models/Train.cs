﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string RouteFromTo { get; set; }
        public DateTime DepartureTime { get; set; }
        public ICollection<TrainRoute> trainRoutes { get; set; }
        
    }
}
