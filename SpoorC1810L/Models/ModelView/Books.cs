using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Models.ModelView
{
    public class Books
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public string Field { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string RouteFromTo { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Toa { get; set; }
        public int Numcloums { get; set; }
        public int Numrows { get; set; }
        public int Total { get; set; }
        public int IdChair { get; set; }
        public int IdCompart { get; set; }
        public int Range { get; set; }
    }
}
